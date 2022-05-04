using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/register")]
    public class RegisterController : Controller
    {
        private readonly UserManager<Student> userManager;
        private readonly SignInManager<Student> signInManager;

        public RegisterController(UserManager<Student> userManager,
                                    SignInManager<Student> signInManager)
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
                var user = new Student
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
