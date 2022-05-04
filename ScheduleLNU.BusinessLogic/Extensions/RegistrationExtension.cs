using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ScheduleLNU.BusinessLogic.Services;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class RegistrationExtension
    {
        public static async Task SignInAsync(this HttpContext context, ClaimsIdentity identities)
        {
            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(identities));
        }

        public static async Task SignInAsync(this HttpContext context, params (object key, object value)[] claimsCookies)
        {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaims(claimsCookies.Select(cookie => new Claim(cookie.key.ToString(), cookie.value.ToString())));

            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(claimsIdentity));
        }

        public static Claim GetClaim(this HttpContext context, string keyValue)
        {
            return context.User.Claims.FirstOrDefault(c => c.Type == keyValue);
        }

        public static bool TryGetStudentId(this HttpContext context, out string studentId)
        {
            var studentEmailAdressClaim = context.GetClaim("studentId");
            studentId = studentEmailAdressClaim?.Value;

            return studentEmailAdressClaim is not null;
        }

        public static IServiceCollection AddCookies(this IServiceCollection services)
        {
            services.AddScoped<ICookieService, CookieService>()
                .AddScoped<ILoginService, LoginService>()
                .ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/authentication/login";
                config.AccessDeniedPath = "/authentication/login";
            });

            return services;
        }
    }
}
