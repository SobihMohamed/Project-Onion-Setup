

using SoftBridge.Abstraction.IServices.Attachement;
using SoftBridge.Abstraction.IServices.Auth;
using SoftBridge.Services.Services;
using SoftBridge.Services.Services.AuthImplementation;

namespace SoftBridge.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Settings
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //3.Services
            //services.AddScoped<I[Name]Service, [Name]Service>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
