using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/login")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginManager;

        public LoginController(ILoginService loginManager)
        {
            this.loginManager = loginManager;
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
                var result = await loginManager.LogInAsync(loginDto);

                if (result)
                {
                    // TODO: redirect to home page
                    return Redirect("~/settings");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(loginDto);
        }
    }
}
