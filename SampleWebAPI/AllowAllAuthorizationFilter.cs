using Hangfire.Dashboard;

namespace SampleWebAPI
{
    public class AllowAllAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Allow all users
            return true; 
        }
    }
}
