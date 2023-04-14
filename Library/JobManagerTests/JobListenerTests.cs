using JobManager.Job;
using Moq;
using Quartz;

namespace JobManagerTests
{
    public class JobListenerTests
    {
        private readonly JobListener _jobListener;
        private readonly Mock<IJobExecutionContext> _contextMock;

        public JobListenerTests()
        {
            _jobListener = new();
            _contextMock = new();
        }

        [Fact]
        public void JobExecutionVetoed_Called()
        {
            _jobListener.JobWasExecutedListener += delegate
            {
                Assert.Fail("Shouldn't be called");
            };

            _jobListener.JobExecutionVetoed(_contextMock.Object);
        }

        [Fact]
        public void JobToBeExecuted_Called()
        {
            _jobListener.JobWasExecutedListener += delegate
            {
                Assert.Fail("Shouldn't be called");
            };

            _jobListener.JobToBeExecuted(_contextMock.Object);
        }

        [Fact]
        public void JobWasExecuted_Called()
        {
            string exceptionMessage = "error";
            IJobExecutionContext? context = null;
            JobExecutionException? exception = null;
            _jobListener.JobWasExecutedListener += (ctx, ex) => 
            {
                context = ctx;
                exception = ex;
            };

            _jobListener.JobWasExecuted(_contextMock.Object, new JobExecutionException(exceptionMessage));

            Assert.NotNull(context);
            Assert.NotNull(exception);
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}