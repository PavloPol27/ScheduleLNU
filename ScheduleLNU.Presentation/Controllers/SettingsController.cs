using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("settings/")]

    /*
     * TODO: split this controller to areas;
     *      1. Add theme settings controller
     *      2. Add events settings controller
     *      3. Add user data settings controller
     */
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> logger;

        private readonly IThemeStyleService stylizationService;

        public SettingsController(ILogger<SettingsController> injectedLogger,
            IThemeStyleService injectedStylizationService)
        {
            logger = injectedLogger;
            stylizationService = injectedStylizationService;
        }

        [Route("")]
        public IActionResult Settings()
        {
            logger.LogInformation("Student oppened settings page");
            return View();
        }

        [HttpGet]

        // TODO: remove onclick with aspnet tag helpers
        [Route("themes")]
        public async Task<IActionResult> Themes()
        {
            logger.LogInformation("Student oppened themes setting page");
            var allThemes = Enumerable.Empty<ThemeDTO>();

            // TODO: replace try catch into one filter place
            try
            {
                allThemes = await stylizationService.GetAllThemesAsync(1);
                logger.LogInformation("Student viwed all themes {Lenght}", allThemes.Count());
            }
            catch (Exception e)
            {
                logger.LogError("Selecting all themes caused {error}", e.Message);
            }

            return View(allThemes);
        }

        [HttpPost]
        [Route("themes")]

        public async Task<IActionResult> Themes(Theme theme)
        {
            logger.LogInformation("Student add new theme {Title} {ForeColor} {BackColor} {Font} {FontSize}",
                theme.Title, theme.ForeColor, theme.BackColor, theme.Font, theme.FontSize);
            try
            {
                await stylizationService.Insert(1, theme);
                logger.LogInformation("New theme wass successfully added");
            }
            catch (Exception e)
            {
                logger.LogError("Insertation of new theme caused {error}", e.Message);
            }

            return Redirect("~/settings/themes");
        }
    }
}
