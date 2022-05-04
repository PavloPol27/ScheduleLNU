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
        public IActionResult Index()
        {
            loginService.SignInAsync(("studentId", "c010d4ba-8ba3-47f7-bc41-a2481201c63c"));
            return View();
        }

        [Route("")]
        [HttpPost]
        public IActionResult Index(int studentId)
        {
            return Redirect("~/settings/themes");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
