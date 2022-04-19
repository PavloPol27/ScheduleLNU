using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("settings/")]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> logger;

        private readonly IStylizationService stylizationService;

        public SettingsController(ILogger<SettingsController> injectedLogger,
            IStylizationService injectedStylizationService)
        {
            logger = injectedLogger;
            stylizationService = injectedStylizationService;
        }

        [Route("themes")]
        [HttpGet]
        public async Task<IActionResult> Themes()
        {
            logger.LogInformation("Student views all themes");
            var allThemes = await stylizationService.GetAllThemesAsync(1);
            return View(allThemes);
        }

        [HttpPost]
        [Route("themes")]
        public async Task<IActionResult> Themes(string title, string foreColor, string backColor, string font, int fontSize)
        {
            logger.LogInformation("User selected forecolor = {foreColor}", foreColor);
            await stylizationService.Insert(1, new Theme() { Title = title, ForeColor = foreColor, BackColor = backColor, Font = font, FontSize = fontSize });
            return Redirect("~/settings/themes");
        }
    }
}
