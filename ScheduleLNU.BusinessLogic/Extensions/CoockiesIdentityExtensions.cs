using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace ScheduleLNU.BusinessLogic.Extensions
{
    public static class CoockiesIdentityExtensions
    {
        public static ClaimsIdentity AddDataRow(this ClaimsIdentity claimIdentity, object key, object value)
        {
            claimIdentity.AddClaim(new Claim(key.ToString(), value.ToString()));
            return claimIdentity;
        }

        public static async Task SignInAsync(this HttpContext context, ClaimsIdentity identities)
        {
            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(identities));
        }

        public static async Task SignInAsync(this HttpContext context, params (object, object)[] claimsCookies)
        {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var (key, value) in claimsCookies)
            {
                claimsIdentity.AddDataRow(key, value);
            }

            await context.SignInAsync("Identity.Application", new ClaimsPrincipal(claimsIdentity));
        }

    }
}
