using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IStudentService studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            this.logger = logger;
            this.studentService = studentService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
