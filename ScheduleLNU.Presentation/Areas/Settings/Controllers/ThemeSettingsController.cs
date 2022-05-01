using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Settings.Controllers
{
    [Area("settings")]
    public class ThemeSettingsController : Controller
    {
        private readonly ILogger<ThemeSettingsController> logger;

        private readonly IThemeStyleService themeService;

        public ThemeSettingsController(ILogger<ThemeSettingsController> injectedLogger,
            IThemeStyleService injectedThemeService)
        {
            logger = injectedLogger;
            themeService = injectedThemeService;
        }

        [HttpGet]
        [Route("[area]/themes")]
        public async Task<IActionResult> Themes()
        {
            logger.LogInformation("Student oppened themes setting page");
            if (Request.Cookies["studentId"] is null)
            {
                return null;
            }

            var allThemes = await themeService.GetAllThemesAsync(int.Parse(Request.Cookies["studentId"]));

            logger.LogInformation("Student viwed all themes {Lenght}", allThemes.Count());

            return View(allThemes);
        }

        [HttpGet]
        [Route("[area]/theme")]
        public async Task<IActionResult> Theme(int studentId, int themeId)
        {
            logger.LogInformation("Student {studentID} openned theme {themeID}", studentId, themeId);

            var theme = await themeService.ViewTheme(studentId, themeId);

            return View(theme);
        }

        [HttpGet]
        [Route("[area]/theme-preview")]
        public IActionResult ThemePreview(int studentId)
        {
            logger.LogInformation("Student {studentID} craetes new theme", studentId);

            return View(new Theme());
        }

        [HttpPost]
        [Route("[area]/add-theme")]

        // TODO: remove theme as DTO
        public async Task<IActionResult> AddTheme(int studentId, Theme theme)
        {
            logger.LogInformation("Student add new theme {Title} {ForeColor} {BackColor} {Font} {FontSize}",
                theme.Title, theme.ForeColor, theme.BackColor, theme.Font, theme.FontSize);

            await themeService.Insert(studentId, theme);

            logger.LogInformation("New theme wass successfully added");

            return Redirect("~/settings/themes");
        }

        [HttpPost]
        [Route("[area]/edit-theme")]

        // TODO: remove theme as DTO
        public async Task<IActionResult> EditTheme(int studentId, Theme theme)
        {
            logger.LogInformation("Student add new theme {Title} {ForeColor} {BackColor} {Font} {FontSize}",
                theme.Title, theme.ForeColor, theme.BackColor, theme.Font, theme.FontSize);

            await themeService.Edit(studentId, theme);

            logger.LogInformation("Theme {themeID} was successfully edit", theme.Id);

            return Redirect("~/settings/themes");
        }
    }
}
