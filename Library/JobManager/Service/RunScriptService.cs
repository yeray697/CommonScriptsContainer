using Contracts.Scripts;
using Contracts.Scripts.Base;
using JobManager.Job;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Serilog;

namespace JobManager.Service
{
    public class RunScriptService : IRunScriptService
    {

        private readonly ISchedulerFactory _schedulerFactory;
        private readonly JobListener _jobListenerOneOff;
        private IScheduler? _scheduler;

        public event IRunScriptService.ScriptExecutedHandler? OneOffScriptExecuted;
        public event IRunScriptService.ScriptExecutedHandler? ScriptStarted;

        public RunScriptService()
        {
            _schedulerFactory = new StdSchedulerFactory();
            _jobListenerOneOff = new JobListener();
            _jobListenerOneOff.JobWasExecutedListener += OneOffJobWasExecuted;
        }
        public async Task RunServiceAsync()
        {
            if (!_scheduler?.IsStarted ?? true)
            {
                Log.Information("Running RunScriptService...");
                if (_scheduler == null)
                {
                    _scheduler = await _schedulerFactory.GetScheduler();
                    _scheduler.ListenerManager.AddJobListener(_jobListenerOneOff, GroupMatcher<JobKey>.GroupEquals(ScriptType.OneOff.ToString()));
                }
                await _scheduler.Start();
            }
        }
        public async Task StopServiceAsync()
        {
            if (_scheduler != null)
            {
                await _scheduler.Shutdown();
                Log.Information("Stopping RunScriptService...");
            }
        }
        public async Task RunScriptAsync(ScriptAbs script)
        {
            await RunServiceAsync();
            if (script.ScriptType is ScriptType.Scheduled)
                Log.Information("Schedule Job for script {@ScriptName} ({@ScriptType}) at {@ScheduledHour}", script.ScriptName, script.ScriptType, ((ScriptScheduled)script).ScheduledHour.ToString());
            else
                Log.Information("Schedule Job for script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            JobKey jobKey = GetJobKeyForScript(script);
            ScriptStarted?.Invoke(script.Id);
            if (await _scheduler!.CheckExists(jobKey))
            {
                await _scheduler.ResumeJob(jobKey);
            }
            else
            {
                var job = CreateJob(script);
                var trigger = CreateTrigger(script);
                job.JobDataMap.Put("script", script);

                await _scheduler.ScheduleJob(job, trigger);
            }
        }
        public async Task StopScriptAsync(ScriptAbs script)
        {
            if (_scheduler != null)
            {
                Log.Information("Stopping Job for script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
                if (script is ScriptScheduled)
                    await _scheduler.UnscheduleJob(GetTriggerKeyForScript(script));
                else
                    await _scheduler.PauseJob(GetJobKeyForScript(script));
            }
        }
        private void OneOffJobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException)
        {
            string scriptId = context.JobDetail.Key.Name;
            OneOffScriptExecuted?.Invoke(scriptId);
        }
        private static IJobDetail CreateJob(ScriptAbs script)
        {
            return JobBuilder
                .Create<RunScriptJob>()
                .WithIdentity(GetJobKeyForScript(script))
                .WithDescription(script.ToString())
                .Build();
        }
        private static ITrigger CreateTrigger(ScriptAbs script)
        {
            TriggerBuilder triggerBuilder = TriggerBuilder
                .Create()
                .WithIdentity(GetTriggerKeyForScript(script));

            if (script is ScriptScheduled scriptScheduled)
            {
                triggerBuilder
                    .StartAt(GetTriggerStartAt(scriptScheduled.ScheduledHour))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInHours(24)
                        .RepeatForever()
                    );
            }
            else
                triggerBuilder.StartNow();

            return triggerBuilder.Build();
        }
        private static DateTimeOffset GetTriggerStartAt(TimeSpan scheduledHour)
        {
            DateTimeOffset startAt = DateTimeOffset.Now.Date + scheduledHour;

            if (DateTimeOffset.Now > startAt)
                startAt = startAt.AddDays(1);

            return startAt;
        }
        private static JobKey GetJobKeyForScript(ScriptAbs script)
        {
            return new JobKey(script.Id, script.ScriptType.ToString());
        }
        private static TriggerKey GetTriggerKeyForScript(ScriptAbs script)
        {
            return new TriggerKey($"{script.Id}.trigger", script.ScriptType.ToString());
        }
    }
}
