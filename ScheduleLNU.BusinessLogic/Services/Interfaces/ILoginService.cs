using ScheduleLNU.BusinessLogic.DTOs;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LogInAsync(LoginDto loginDto);
    }
}
