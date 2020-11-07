using Quartz;
using System.Threading;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service.Job
{
    public class JobListener : IJobListener
    {
        public delegate void JobExecutedHandler(IJobExecutionContext context, JobExecutionException jobException);
        public event JobExecutedHandler JobWasExecutedListener;


        public string Name => "JobListener";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult(true);

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult(true);

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            JobWasExecutedListener?.Invoke(context, jobException);
            return Task.FromResult(true);
        }
    }
}
