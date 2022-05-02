using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/login")]
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Login(LoginDto loginDto)
        {
            return View();
        }
    }
}
