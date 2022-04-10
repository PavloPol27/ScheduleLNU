using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD:WebAPI/Startup.cs
using Application.Services;
using Application.Services.Interfaces;
using Domain.Repository;

namespace WebAPI
=======
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Repository;

namespace Presentation
>>>>>>> create_layered_architecture:ScheduleLNU.Presentation/Startup.cs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

<<<<<<< HEAD:WebAPI/Startup.cs

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureDbServices(services);
            services.AddScoped<IStudentService, StudentService>();
            services.AddRazorPages();
            services.AddHttpClient();
        }


=======
        public void ConfigureServices(IServiceCollection services)
        {

            ConfigureDbServices(services);
            services.AddScoped<IStudentService, StudentService>();
            services.AddMvc();
            services.AddHttpClient();
        }

>>>>>>> create_layered_architecture:ScheduleLNU.Presentation/Startup.cs
        private void ConfigureDbServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           
        }

<<<<<<< HEAD:WebAPI/Startup.cs

=======
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
>>>>>>> create_layered_architecture:ScheduleLNU.Presentation/Startup.cs
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
<<<<<<< HEAD:WebAPI/Startup.cs
            
=======
           
>>>>>>> create_layered_architecture:ScheduleLNU.Presentation/Startup.cs
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
