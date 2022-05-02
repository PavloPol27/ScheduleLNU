using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class CoockieIdentityExtensions
    {
        public static async Task SignInAsync(this HttpContext context, ClaimsIdentity identities)
        {
            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(identities));
        }

        public static async Task SignInAsync(this HttpContext context, params (object, object)[] claimsCookies)
        {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaims(claimsCookies.Select((key, value) => new Claim(key.ToString(), value.ToString())));

            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(claimsIdentity));
        }

        public static Claim GetClaim(this HttpContext context, string keyValue)
        {
            return context.User.Claims
                 .FirstOrDefault(c => c.Type
                 .Equals(keyValue, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool TryGetStudentEmailAddress(this HttpContext context, out string studentId)
        {
            var studentEmailAdressClaim = context.GetClaim("studentEmailAddress");
            studentId = studentEmailAdressClaim?.Value;

            return studentEmailAdressClaim is not null;
        }
    }
}
