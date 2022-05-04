using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Extensions;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{

    [Area("authentication")]
    [Route("[area]/register")]
    public class RegisterController : Controller
    {
        private readonly UserManager<StudentAspIdentity> userManager;
        private readonly SignInManager<StudentAspIdentity> signInManager;

        public RegisterController(UserManager<StudentAspIdentity> userManager,
                                    SignInManager<StudentAspIdentity> signInManager)
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
                var user = new StudentAspIdentity
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    // NormalizedUserName = $"{registerDto.FirstName} {registerDto.LastName}"
                };

                var result = await userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    // await signInManager.SignInAsync(user, isPersistent: false);
                    // await HttpContext.SignInAsync((ClaimsIdentity.DefaultNameClaimType, user.Id));
                    return RedirectToAction("view", "Schedules");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerDto);
        }
    }
}
