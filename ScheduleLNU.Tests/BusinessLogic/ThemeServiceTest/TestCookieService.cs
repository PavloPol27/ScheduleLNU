using System.Security.Claims;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Tests.BusinessLogic.ThemeServiceTest
{
    internal class TestCookieService : ICookieService
    {
        private readonly string _cookieId;

        public TestCookieService(string cokkieId)
        {
            _cookieId = cokkieId;
        }

        public Claim GetClaim(string key)
        {
            throw new System.NotImplementedException();
        }

        public string GetStudentId()
        {
            return _cookieId;
        }

        public Task SetCookies(params (object, object)[] claimsCookie)
        {
            throw new System.NotImplementedException();
        }

        public Task LogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}