using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using ScheduleLNU.BusinessLogic.DTOs;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{

    [Area("authentication")]
    [Route("[area]/register")]
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = $"{registerDto.FirstName} {registerDto.LastName}",
                    Email = registerDto.Email,
                };

                var result = await userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("view", "Schedules");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(registerDto);
        }
    }
}
