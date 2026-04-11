
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;

namespace SoftBridge.Web.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection InjectIdentityCore(this IServiceCollection services)
        {
            // Add Identity services
           
            return services;
        }
        public static IServiceCollection InjectRateLimiting(this IServiceCollection services)
        {
            // Add rate limiting services

            return services;
        }
    }
}
