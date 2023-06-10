using Contracts.Scripts;
using Contracts.Scripts.Base;
using JobManager.Job;
using JobManager.Service;
using Moq;
using Quartz;
using Quartz.Impl.Matchers;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JobManagerTests
{
    public class RunScriptServiceTests
    {
        private const string DefaultScriptId = "someId";
        private const string DefaultScriptName = "name";

        private readonly Mock<ISchedulerFactory> _schedulerFactoryMock;
        private readonly Mock<JobListener> _jobListenerOneOffMock;
        private readonly Mock<IScheduler> _schedulerMock;
        private readonly Mock<IListenerManager> _listenerManagerMock;
        private readonly IRunScriptService _runScriptService;

        public RunScriptServiceTests()
        {
            _schedulerFactoryMock = new();
            _jobListenerOneOffMock = new();
            _schedulerMock = new();
            _listenerManagerMock = new();

            _schedulerMock.Setup(t => t.ListenerManager)
                .Returns(_listenerManagerMock.Object);
            
            _schedulerFactoryMock.Setup(t => t.GetScheduler(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_schedulerMock.Object);
            _runScriptService = new RunScriptService(_schedulerFactoryMock.Object, _jobListenerOneOffMock.Object);
        }

        [Fact]
        public async Task RunServiceAsync_SchedulerNull_Initialize()
        {
            SetupAddJobListener();

            await _runScriptService.RunServiceAsync();

            VerifyGetScheduler(Times.Once());
            VerifyAddJobListener(Times.Once());
            VerifySchedulerStart(Times.Once());
        }

        [Fact]
        public async Task RunServiceAsync_SchedulerNotNullAndStarted_NoAction()
        {
            SetupAddJobListener();
            await _runScriptService.RunServiceAsync(); //First time to initialize
            _schedulerMock.Setup(t => t.IsStarted).Returns(true);

            await _runScriptService.RunServiceAsync(); //Run a second time

            //Verify that methods only gets called once, as the second run detects is already initialized
            VerifyGetScheduler(Times.Once());
            VerifyAddJobListener(Times.Once());
            VerifySchedulerStart(Times.Once());
        }

        [Fact]
        public async Task RunServiceAsync_SchedulerNotNullAndNotStarted_StartsScheduler()
        {
            SetupAddJobListener();
            await _runScriptService.RunServiceAsync(); //First time to initialize
            _schedulerMock.Setup(t => t.IsStarted).Returns(false); //Simulate it is not started (is this possible???)

            await _runScriptService.RunServiceAsync(); //Run a second time

            //Scheduler is initialized so GetScheduler and AddJobListener only gets called once, as the second run detects is already initialized
            VerifyGetScheduler(Times.Once());
            VerifyAddJobListener(Times.Once());
            //Scheduler is initialized but was not started, so the second run starts it
            VerifySchedulerStart(Times.Exactly(2));
        }
        
        [Theory]
        [InlineData(ScriptType.OneOff)]
        [InlineData(ScriptType.Scheduled)]
        public async Task RunScriptAsync_ScriptDoesNotExist_ScheduleJob(ScriptType scriptType)
        {
            ScriptAbs script;
            if (scriptType == ScriptType.OneOff)
                script = GetOneOffScript();
            else if (scriptType == ScriptType.Scheduled)
                script = GetScheduledScript();
            else
                throw new ArgumentOutOfRangeException(nameof(scriptType));
            string scriptStartedId = string.Empty;
            _runScriptService.ScriptStarted += (string scriptId) =>
            {
                scriptStartedId = scriptId;
            };

            await _runScriptService.RunScriptAsync(script);

            Assert.Equal(script.Id, scriptStartedId);
            VerifyCheckExists(script, Times.Once());
            VerifyScheduleJob(script, Times.Once());
            VerifyResumeJob(script, Times.Never());
        }

        [Fact]
        public async Task RunScriptAsync_ScriptExists_Resume()
        {
            ScriptAbs script = GetOneOffScript();
            _schedulerMock.Setup(t => t.CheckExists(It.Is<JobKey>(jk => VerifyJobKey(jk, script)), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            string scriptStartedId = string.Empty;
            _runScriptService.ScriptStarted += (string scriptId) =>
            {
                scriptStartedId = scriptId;
            };

            await _runScriptService.RunScriptAsync(script);

            Assert.Equal(script.Id, scriptStartedId);
            VerifyCheckExists(script, Times.Once());
            VerifyScheduleJob(script, Times.Never());
            VerifyResumeJob(script, Times.Once());
        }

        [Fact]
        public async Task StopScriptAsync_SchedulerNull_NoAction()
        {
            ScriptAbs script = GetOneOffScript();

            await _runScriptService.StopScriptAsync(script);

            VerifyUnscheduleJob(script, Times.Never());
            VerifyPauseJob(script, Times.Never());
        }

        [Fact]
        public async Task StopScriptAsync_ScritpScheduled_Unschedule()
        {
            ScriptAbs script = GetScheduledScript();
            SetupAddJobListener();
            await _runScriptService.RunServiceAsync(); //Init _scheduler

            await _runScriptService.StopScriptAsync(script);

            VerifyUnscheduleJob(script, Times.Once());
            VerifyPauseJob(script, Times.Never());
        }

        [Fact]
        public async Task StopScriptAsync_ScritpOneOff_Pause()
        {
            ScriptAbs script = GetOneOffScript();
            SetupAddJobListener();
            await _runScriptService.RunServiceAsync(); //Init _scheduler

            await _runScriptService.StopScriptAsync(script);

            VerifyUnscheduleJob(script, Times.Never());
            VerifyPauseJob(script, Times.Once());
        }

        [Fact]
        public async Task StopServiceAsync_SchedulerNotNull_Stopped()
        {
            SetupAddJobListener();
            await _runScriptService.RunServiceAsync(); //Init _scheduler

            await _runScriptService.StopServiceAsync();

            _schedulerMock.Verify(t => t.Shutdown(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task StopServiceAsync_SchedulerNull_NoAction()
        {
            await _runScriptService.StopServiceAsync();

            _schedulerMock.Verify(t => t.Shutdown(It.IsAny<CancellationToken>()), Times.Never());
        }

        private void SetupAddJobListener()
        {
            _listenerManagerMock.Setup(t => t.AddJobListener(
                    It.Is<IJobListener>(jl => jl == _jobListenerOneOffMock.Object),
                    It.Is<IMatcher<JobKey>>(m => ((StringMatcher<JobKey>)m).CompareToValue == ScriptType.OneOff.ToString()))
                );
        }

        private static bool VerifyJobKey(JobKey jobKey, ScriptAbs script)
        {
            string expectedJobName = script.Id;
            string expectedJobGroup = script.ScriptType.ToString();
            return jobKey.Name == expectedJobName && jobKey.Group == expectedJobGroup;
        }

        private static bool VerifyTriggerKey(TriggerKey triggerKey, ScriptAbs script)
        {
            return triggerKey.Name == $"{script.Id}.trigger" && triggerKey.Group == script.ScriptType.ToString();
        }

        private void VerifyGetScheduler(Times times)
        {
            _schedulerFactoryMock.Verify(t => t.GetScheduler(It.IsAny<CancellationToken>()), times);
        }

        private void VerifyAddJobListener(Times times)
        {
            _listenerManagerMock.Verify(t =>
                t.AddJobListener(
                    It.Is<IJobListener>(jl => jl == _jobListenerOneOffMock.Object),
                    It.Is<IMatcher<JobKey>>(m => ((StringMatcher<JobKey>)m).CompareToValue == ScriptType.OneOff.ToString())),
                times);
        }

        private void VerifySchedulerStart(Times times)
        {
            _schedulerMock.Verify(t => t.Start(It.IsAny<CancellationToken>()), times);
        }

        private void VerifyUnscheduleJob(ScriptAbs script, Times times)
        {
            _schedulerMock.Verify(t => t.UnscheduleJob(It.Is<TriggerKey>(tk => VerifyTriggerKey(tk, script)), It.IsAny<CancellationToken>()), times);
        }

        private void VerifyPauseJob(ScriptAbs script, Times times)
        {
            _schedulerMock.Verify(t => t.PauseJob(It.Is<JobKey>(jk => VerifyJobKey(jk, script)), It.IsAny<CancellationToken>()), times);
        }

        private static bool VerifyTrigger(ITrigger trigger, ScriptAbs script)
        {
            return VerifyTriggerKey(trigger.Key, script)
                && (
                    (script is ScriptScheduled && trigger.StartTimeUtc.Day == DateTime.UtcNow.AddDays(1).Day) // tomorrow
                    || (script is not ScriptScheduled) && trigger.StartTimeUtc.Day == DateTime.UtcNow.Day // today, i.e. now;
                );
        }

        private void VerifyCheckExists(ScriptAbs script, Times times)
        {
            _schedulerMock.Verify(t => t.CheckExists(It.Is<JobKey>(jk => VerifyJobKey(jk, script)), It.IsAny<CancellationToken>()),
                times);
        }

        private void VerifyScheduleJob(ScriptAbs script, Times times)
        {
            _schedulerMock.Verify(t => t.ScheduleJob(It.Is<IJobDetail>(jd => VerifyJobKey(jd.Key, script)),
                    It.Is<ITrigger>(tg => VerifyTrigger(tg, script)),
                    It.IsAny<CancellationToken>()),
                times);
        }

        private void VerifyResumeJob(ScriptAbs script, Times times)
        {
            _schedulerMock.Verify(t => t.ResumeJob(It.Is<JobKey>(jk => VerifyJobKey(jk, script)),
                    It.IsAny<CancellationToken>()),
                times);
        }

        private static ScriptAbs GetOneOffScript(string id = DefaultScriptId, string name = DefaultScriptName)
        {
            return new ScriptOneOff()
            {
                Id = id,
                ScriptName = name
            };
        }

        private static ScriptAbs GetScheduledScript(string id = DefaultScriptId, string name = DefaultScriptName)
        {
            DateTime dt = DateTime.UtcNow.AddDays(1);
            return new ScriptScheduled()
            {
                Id = id,
                ScriptName = name,
                ScheduledHour = new TimeSpan(dt.Hour, dt.Minute, dt.Second)
            };
        }
    }
}
