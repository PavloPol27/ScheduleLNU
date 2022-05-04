using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ScheduleLNU.Presentation.Controllers
{
    [Area("settings")]
    [Authorize]
    public class ConfigurationController : Controller
    {
        private readonly ILogger<ConfigurationController> logger;

        public ConfigurationController(ILogger<ConfigurationController> injectedLogger)
        {
            logger = injectedLogger;
        }

        [HttpGet]
        [Route("[area]")]
        public IActionResult SettingsMenu()
        {
            logger.LogInformation("Student oppened settings page");
            return View();
        }
    }
}
