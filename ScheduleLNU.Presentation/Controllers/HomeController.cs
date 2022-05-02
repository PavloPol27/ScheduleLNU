using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.Extensions;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Index(int studentId)
        {
            await HttpContext.SignInAsync((nameof(studentId), studentId));
            return Redirect("~/settings/themes");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
