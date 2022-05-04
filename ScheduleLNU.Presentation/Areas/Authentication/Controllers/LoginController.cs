using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/login")]
    public class LoginController : Controller
    {
        private readonly SignInManager<Student> signInManager;

        public LoginController(SignInManager<Student> signInManager)
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
    }
}
