

namespace E_commerce.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Settings
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //3.Services
            //services.AddScoped<I[Name]Service, [Name]Service>();


            return services;
        }
    }
}
