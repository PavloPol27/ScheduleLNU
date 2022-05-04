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
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignInAsync(("studentId", "58e16f9d-75be-44bc-9d91-43b0208226cc"));
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
