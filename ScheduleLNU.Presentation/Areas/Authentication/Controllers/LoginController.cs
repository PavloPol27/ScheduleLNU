using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/login")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> logger;

        private readonly IAuthService authService;
        private readonly ILoginService loginService;

        public LoginController(ILogger<LoginController> logger,
            IAuthService authService,
            ILoginService loginService)
        {
            this.logger = logger;
            this.authService = authService;
            this.loginService = loginService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await loginService.LogInAsync(loginDto);

                if (result)
                {
                    // TODO: redirect to home page
                    return Redirect("~/settings");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(loginDto);
        }

        [HttpGet]
        [Route("forgot-password")]
        public ActionResult ForgotPasswordForm()
        {
            return View();
        }

        [HttpPost]
        [Route("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            await authService.SendResetTokenAsync(forgotPasswordDto.Email);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("reset-password")]
        public ActionResult ResetPasswordForm(string email, string token)
        {
            var resetPasswordDto = new ResetPasswordDto { Email = email, Token = token };
            return View(resetPasswordDto);
        }

        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await authService.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.Token, resetPasswordDto.NewPassword, resetPasswordDto.ConfirmedPassword);
            if (ModelState.IsValid && result)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }
    }
}
