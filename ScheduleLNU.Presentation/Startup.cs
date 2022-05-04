using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleLNU.BusinessLogic.Extensions;
using ScheduleLNU.BusinessLogic.Extensions.ServicesExtension;
using ScheduleLNU.BusinessLogic.Services;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using Serilog;

namespace ScheduleLNU.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbConfiguration(Configuration["ConnectionString"]);
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddSettingServices();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddHttpClient();
            services.AddCookies();
            services.Configure<PasswordHasherOptions>(options =>
                        options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandling(Log.Logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
