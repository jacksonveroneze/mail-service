using Hangfire.Dashboard;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public class HangfireDashboardNoAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext dashboardContext)
            => true;
    }
}
