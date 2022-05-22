using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class RegistrationExtensions
    {
        public static async Task SignInAsync(this HttpContext context, params (object key, object value)[] claimsCookies)
        {
            var claimsIdentity = new ClaimsIdentity("Identity.Application");
            claimsIdentity.AddClaims(claimsCookies.Select(cookie => new Claim(cookie.key.ToString(), cookie.value.ToString())));

            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(claimsIdentity));
        }

        public static Claim GetClaim(this HttpContext context, string keyValue)
        {
            return context.User.Claims.FirstOrDefault(c => c.Type == keyValue);
        }

        public static string GetStudentId(this HttpContext context)
        {
            var studentEmailAdressClaim = context.GetClaim("studentId");
            return studentEmailAdressClaim?.Value;
        }
    }
}
