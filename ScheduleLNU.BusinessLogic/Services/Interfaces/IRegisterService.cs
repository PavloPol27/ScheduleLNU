using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<Microsoft.AspNetCore.Identity.IdentityResult> RegisterAsync(RegisterDto registerDto);
    }
}
