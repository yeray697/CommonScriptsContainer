using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Model.Service.Job;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service
{
    public class RunScriptService : IRunScriptService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IJobListener _jobListenerOneOff;
        public IScheduler Scheduler { get; set; }

        public RunScriptService()
        {
            _schedulerFactory = new StdSchedulerFactory();
        }

        public async Task Run()
        {
            if (!Scheduler?.IsStarted ?? true)
            {
                Log.Information("Running RunScriptService...");
                if (Scheduler == null)
                {
                    Scheduler = await _schedulerFactory.GetScheduler();
                    AddJobListener(_jobListenerOneOff, ScriptType.OneOff.ToString());
                }
                await Scheduler.Start();
            }
        }
        public async Task RunScript(ScriptAbs script)
        {
            await Run();
            if (script.ScriptType is ScriptType.Scheduled)
                Log.Information("Schedule Job for script {@ScriptName} ({@ScriptType}) at {@ScheduledHour}", script.ScriptName, script.ScriptType, ((ScriptScheduled) script).ScheduledHour.ToString());
            else
                Log.Information("Schedule Job for script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            JobKey jobKey = GetJobKeyForScript(script);
            if (await Scheduler.CheckExists(jobKey))
            {
                await Scheduler.ResumeJob(jobKey);
            }
            else
            {
                var job = CreateJob(script);
                var trigger = CreateTrigger(script);
                job.JobDataMap.Put("script", script);

                await Scheduler.ScheduleJob(job, trigger);
            }
        }
        public async Task StopScript(ScriptAbs script)
        {
            if (Scheduler != null)
            {
                Log.Information("Stopping Job for script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
                if (script is ScriptScheduled)
                    await Scheduler.UnscheduleJob(GetTriggerKeyForScript(script));
                else
                    await Scheduler.PauseJob(GetJobKeyForScript(script));
            }
        }
        public async Task Stop()
        {
            if (Scheduler != null)
            {
                await Scheduler.Shutdown();
                Log.Information("Stopping RunScriptService...");
            }
        }
        public void SetOneOffJobListener(IJobListener jobListenerOneOff)
        {
            _jobListenerOneOff = jobListenerOneOff;
            AddJobListener(_jobListenerOneOff, ScriptType.OneOff.ToString());
        }
        private void AddJobListener(IJobListener jobListener, string jobGroup)
        {
            if (Scheduler != null)
                Scheduler.ListenerManager.AddJobListener(jobListener, GroupMatcher<JobKey>.GroupEquals(jobGroup));
        }
        private IJobDetail CreateJob(ScriptAbs script)
        {
            return JobBuilder
                .Create<RunScriptJob>()
                .WithIdentity(GetJobKeyForScript(script))
                .WithDescription(script.ToString())
                .Build();
        }
        private ITrigger CreateTrigger(ScriptAbs script)
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
        private DateTimeOffset GetTriggerStartAt(TimeSpan scheduledHour)
        {
            DateTimeOffset startAt = DateTimeOffset.Now.Date + scheduledHour;

            if (DateTimeOffset.Now > startAt)
                startAt = startAt.AddDays(1);

            return startAt;
        }
        private JobKey GetJobKeyForScript(ScriptAbs script)
        {
            return new JobKey(script.Id, script.ScriptType.ToString());
        }
        private TriggerKey GetTriggerKeyForScript(ScriptAbs script)
        {
            return new TriggerKey($"{script.Id}.trigger", script.ScriptType.ToString());
        }
    }
}
