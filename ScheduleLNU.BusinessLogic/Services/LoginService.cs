using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICookieService cookieService;

        public LoginService(ICookieService injectedCookieService)
        {
            cookieService = injectedCookieService;
        }

        public async Task SignInAsync(params (object, object)[] cookies)
        {
            await cookieService.SetCookies(cookies);
        }
    }
}
