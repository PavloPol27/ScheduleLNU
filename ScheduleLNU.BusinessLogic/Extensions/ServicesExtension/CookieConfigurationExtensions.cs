using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.BusinessLogic.Services;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.BusinessLogic.Extensions.ServicesExtension
{
    public static class CookieConfigurationExtensions
    {
        public static IServiceCollection AddCookies(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(config =>
                {
                    config.LoginPath = "/authentication/login";
                    config.AccessDeniedPath = "/authentication/login";
                });

            return services;
        }
    }
}
