using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.DTOs.Mappers;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Settings.Controllers
{
    [Area("settings")]
    [Authorize]
    public class ThemeSettingsController : Controller
    {
        private readonly IThemeStyleService themeService;

        public ThemeSettingsController(IThemeStyleService themeService)
        {
            this.themeService = themeService;
        }

        [HttpGet]
        [Route("[area]/themes")]
        public async Task<IActionResult> Themes()
        {
            var allThemes = await themeService.GetAllThemesAsync();
            return View(allThemes);
        }

        [HttpGet]
        [Route("[area]/theme")]
        public async Task<IActionResult> Theme(int themeId)
        {
            var theme = await themeService.ViewTheme(themeId);
            return View(theme);
        }

        [HttpGet]
        [Route("[area]/theme-preview")]
        public IActionResult ThemePreview()
        {
            return View(new Theme());
        }

        [HttpPost]
        [Route("[area]/add-theme")]
        public async Task<IActionResult> AddTheme(ThemeDto theme)
        {
            await themeService.Insert(theme.ToTheme());
            return Redirect("~/settings/themes");
        }

        [HttpPost]
        [Route("[area]/edit-theme")]
        public async Task<IActionResult> EditTheme(Theme theme)
        {
            await themeService.Edit(theme);
            return Redirect("~/settings/themes");
        }

        [HttpGet]
        [Route("[area]/delete-theme")]
        public IActionResult DeletePopup(ThemeDto scheduleDto)
        {
            return PartialView("_DeletePopUpPartial", scheduleDto);
        }

        [HttpPost]
        [Route("[area]/delete-theme")]
        public async Task<IActionResult> DeleteTheme(ThemeDto themeDto)
        {
            await themeService.DeleteAsync(themeDto.ToTheme());
            return RedirectToAction(nameof(Themes));
        }

        [Route("[area]/select-theme")]
        public async Task<IActionResult> SelectTheme(ThemeDto themeDto)
        {
            if (themeDto.IsSelected)
            {
                await themeService.DeselectAsync();
            }
            else
            {
                await themeService.SelectTheme(themeDto.ToTheme());
            }

            return RedirectToAction(nameof(Themes));
        }
    }
}
