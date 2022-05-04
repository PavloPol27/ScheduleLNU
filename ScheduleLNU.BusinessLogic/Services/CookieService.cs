using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ScheduleLNU.BusinessLogic.Extensions;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CookieService(IHttpContextAccessor injectedContextAccessor)
        {
            httpContextAccessor = injectedContextAccessor;
        }

        public Claim GetClaim(string key)
        {
            return httpContextAccessor.HttpContext.GetClaim(key);
        }

        public async Task SetCookies(params (object, object)[] claimsCookie)
        {
            await httpContextAccessor.HttpContext.SignInAsync(claimsCookie);
        }
    }
}
