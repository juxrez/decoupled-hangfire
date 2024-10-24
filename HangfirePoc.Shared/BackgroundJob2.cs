using Microsoft.Extensions.Logging;

namespace HangfirePoc.Shared
{
    public class BackgroundJob2
    {
        private readonly ILogger<BackgroundJob2> _logger;

        public BackgroundJob2(ILogger<BackgroundJob2> logger)
        {
            _logger = logger;
        }

        public Task Execute()
        {
            try
            {
                throw new Exception("Testing exceptions", new Exception("Inner exception"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
            }
           
            return Task.CompletedTask;
        }
    }
}
