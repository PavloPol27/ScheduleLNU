using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ScheduleLNU.Presentation.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> logger;

        public SettingsController(ILogger<SettingsController> injectedLogger)
        {
            logger = injectedLogger;
        }

        [HttpGet]
        public IActionResult Themes()
        {
            logger.LogInformation("Student views all themes");
            return View();
        }
    }
}
