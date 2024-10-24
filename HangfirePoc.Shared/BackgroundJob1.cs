namespace HangfirePoc.Shared
{
    public class BackgroundJob1
    {
        public Task Execute()
        {
            Console.WriteLine("BackgroundJob1 ran");

            return Task.CompletedTask;
        }
    }
}
