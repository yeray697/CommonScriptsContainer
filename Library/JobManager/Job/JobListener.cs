using Quartz;

namespace JobManager.Job
{
    public class JobListener : IJobListener
    {
        public delegate void JobExecutedHandler(IJobExecutionContext context, JobExecutionException? jobException);
        public event JobExecutedHandler? JobWasExecutedListener;
        public string Name => "JobListener";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
        {
            JobWasExecutedListener?.Invoke(context, jobException);
            return Task.FromResult(true);
        }
    }
}
