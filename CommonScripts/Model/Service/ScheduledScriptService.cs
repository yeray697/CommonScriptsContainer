using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Model.Pojo;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service
{
    public class ScheduledScriptService : IRunnableService
    {
        private bool _running;

        public List<ScriptScheduled> Scripts { get; set; }

        public ScheduledScriptService()
        {

        }



        public void Run()
        {
            if (Scripts != null && Scripts.Count > 0)
            {
                _running = true;
                RunPeriodically();
            }
        }
        private async Task RunPeriodically()
        {/*
            // construct a scheduler factory
            NameValueCollection props = new NameValueCollection
        {
            { "quartz.serializer.type", "binary" }
        };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            // get a scheduler
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<TestJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();

            await sched.ScheduleJob(job, trigger);*/
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
