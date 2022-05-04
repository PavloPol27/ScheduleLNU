using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILoginService loginService;

        public HomeController(ILoginService injectedLoginService)
        {
            loginService = injectedLoginService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await loginService.SignInAsync(("studentId", "58e16f9d-75be-44bc-9d91-43b0208226cc"));
            return View();
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Index(int studentId)
        {
            await loginService.SignInAsync(("studentId", studentId.ToString()));
            return Redirect("~/settings/themes");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
