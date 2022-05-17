using System.Security.Claims;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface ICookieService
    {
        public Claim GetClaim(string key);

        public Task SetCookies(params (object, object)[] claimsCookie);

        public Task LogOut();

        public string GetStudentId();
    }
}
