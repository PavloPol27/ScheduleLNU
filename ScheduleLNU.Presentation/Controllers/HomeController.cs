using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
