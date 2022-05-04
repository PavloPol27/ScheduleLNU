using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        Task SendResetTokenAsync(string email);

        Task ResetPasswordAsync(string email, string token, string newPassword, string confirmedPassword);
    }
}
