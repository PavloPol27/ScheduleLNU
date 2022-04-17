using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.DataAccess;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void SetupDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}