using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Settings.Controllers
{
    [Area("Settings")]
    [Route("[area]/event-styles")]
    public class EventStyleSettingsController : Controller
    {
        private readonly ILogger<EventStyleSettingsController> logger;

        private readonly IEventStyleService eventStyleService;

        public EventStyleSettingsController(ILogger<EventStyleSettingsController> logger,
            IEventStyleService eventStyleService)
        {
            this.logger = logger;
            this.eventStyleService = eventStyleService;
        }

        [HttpGet]
        public async Task<IActionResult> EventStyles()
        {
            logger.LogInformation("Student oppened event styles page");
            const int studentId = 228;

            IEnumerable<EventStyleDto> eventStyles = await eventStyleService.GetAllAsync(studentId);

            logger.LogInformation("Student viwed all event styles {Lenght}", eventStyles.Count());

            return View(eventStyles);
        }
    }
}
