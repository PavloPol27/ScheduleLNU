using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.DataAccess.Contexts;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            return services.AddSchedulesDb(connectionString)
                           .AddAspNetIdentityDbContext(connectionString);
        }

        public static IServiceCollection AddSchedulesDb(this IServiceCollection services, string connectionString)
        {
            return services.AddScoped<IdentityDbContext<StudentAspIdentity>, DataContext>()
                           .AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString))
                           .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static IServiceCollection AddAspNetIdentityDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddIdentity<StudentAspIdentity, StudentRoleAspIdentity>(options =>
                           {
                               options.SignIn.RequireConfirmedAccount = true;
                               options.SignIn.RequireConfirmedEmail = true;
                               options.Password.RequiredLength = 6;
                               options.Password.RequireNonAlphanumeric = false;
                               options.Password.RequireUppercase = false;
                               options.Password.RequireLowercase = false;
                           })
                    .AddEntityFrameworkStores<DataContext>();
            return services;
        }
    }
}