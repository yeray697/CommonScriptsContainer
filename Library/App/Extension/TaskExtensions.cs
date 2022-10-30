namespace App.Extension
{
    public static class TaskExtensions
    {
        public static void RunSync(this Task taskToRun)
        {
            Task task = Task.Run(async () => await taskToRun);
            task.Wait();
        }
    }
}
