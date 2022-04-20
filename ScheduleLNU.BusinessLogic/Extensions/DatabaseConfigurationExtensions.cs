using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.BusinessLogic.Services;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbContext, DataContext>();
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static IServiceCollection AddSettings(this IServiceCollection services)
        {
            return services.AddScoped<ITemeStyleService, StylizationService>();
        }
    }
}