using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Model.Service.Job;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service
{
    public class RunScriptService : IRunScriptService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        public IScheduler Scheduler { get; set; }

        public RunScriptService()
        {
            _schedulerFactory = new StdSchedulerFactory();
        }

        public async Task Run()
        {
            if (!Scheduler?.IsStarted ?? true) {
                Scheduler = await _schedulerFactory.GetScheduler();
                await Scheduler.Start();
            }
        }

        public async Task RunScript(ScriptAbs script)
        {
            await Run();
            if (await Scheduler.CheckExists(new JobKey(script.ScriptName)))
            {
                await Scheduler.ResumeJob(new JobKey(script.ScriptName));
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
            await Scheduler.PauseJob(new JobKey(script.ScriptName));
        }

        public async Task Stop()
        {
            await Scheduler?.Shutdown();
        }

        private IJobDetail CreateJob(ScriptAbs script)
        {
            return JobBuilder
                .Create<RunScriptJob>()
                .WithIdentity(script.ScriptName)
                .WithDescription(script.ToString())
                .Build();
        }

        private ITrigger CreateTrigger(ScriptAbs script)
        {
            TriggerBuilder triggerBuilder = TriggerBuilder
                .Create()
                .WithIdentity($"{script.ScriptName}.trigger");

            if (script is ScriptScheduled)
            {
                triggerBuilder
                    .StartAt(GetTriggerStartAt(((ScriptScheduled)script).ScheduledHour))
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
    }
}
