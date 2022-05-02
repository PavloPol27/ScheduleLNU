using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.BusinessLogic.Services;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static IServiceCollection AddSettingServices(this IServiceCollection services)
        {
            return services.AddScoped<IThemeStyleService, ThemeStyleService>()
                           .AddScoped<IEventStyleService, EventStyleService>()
                           .AddScoped<IAuthService, AuthService>();
        }
    }
}
