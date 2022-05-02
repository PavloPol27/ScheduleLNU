using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScheduleLNU.BusinessLogic.Services.EmailService;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<StudentAspIdentity> userManager;
        private IEmailSender emailSender;

        public AuthService(UserManager<StudentAspIdentity> userManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public async Task SendResetTokenAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NullReferenceException($"User is not found");
            }

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var message = new Message(new string[] { email }, "LNU Schedule, Reset Password",
                "https://localhost:44384/recoveryPassword?email=" + email + "?token=" + resetToken);
            await emailSender.SendEmailAsync(message);
        }

        public async Task ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NullReferenceException($"User is not found");
            }

            await userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}
