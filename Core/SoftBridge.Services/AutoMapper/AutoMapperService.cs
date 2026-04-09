
using Microsoft.Extensions.DependencyInjection;
using SoftBridge.Services.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Services.AutoMapper
{
    public static class AutoMapperService
    {
        public static IServiceCollection InjectAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                //cfg.AddProfile(new [Auth]Profile());
                //cfg.AddProfile(new typeof(ClientProfile));
            });
            return services;
        }
    }
}
