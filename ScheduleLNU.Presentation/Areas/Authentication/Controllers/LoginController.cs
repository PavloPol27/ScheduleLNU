using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public LoginController(ILogger<LoginController> logger,
            IAuthService authService)
        {
            this.logger = logger;
            this.authService = authService;
        }

        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
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
                var result = await signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("view", "Schedules");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(loginDto);
        }

        [HttpGet]
        [Route("forgot-password")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            await authService.SendResetTokenAsync(forgotPasswordDto.Email);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }

        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            await authService.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.Token, resetPasswordDto.NewPassword);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }
    }
}
