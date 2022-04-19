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
            services.AddTransient<DbContext, DataContext>();
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }

        public static IServiceCollection AddStylizationService(this IServiceCollection services)
        {
            return services.AddTransient<IStylizationService, StylizationService>();
        }
    }
}