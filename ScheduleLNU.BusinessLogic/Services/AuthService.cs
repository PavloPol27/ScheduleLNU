using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using ScheduleLNU.BusinessLogic.Services.EmailService;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<Student> userManager;
        private IEmailSender emailSender;

        public AuthService(UserManager<Student> userManager, IEmailSender emailSender)
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
                "https://localhost:44384/authentication/login/reset-password/?email=" + email + "&token=" + HttpUtility.UrlEncode(resetToken));
            await emailSender.SendEmailAsync(message);
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword, string confirmedPassword)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NullReferenceException($"User is not found");
            }

            if (newPassword != confirmedPassword)
            {
                throw new ArgumentException($"New password should be equal to confirmed!");
            }

            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
