using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Extensions;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Areas.Settings.Controllers
{
    [Area("settings")]
    [Route("[area]/event-styles")]
    [Authorize]
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
            var studentId = HttpContext.GetStudentId();
            if (studentId is null)
            {
                return StatusCode(401);
            }

            IEnumerable<EventStyleDto> eventStyles = await eventStyleService.GetAllAsync();
            return View(eventStyles);
        }

        [HttpPost]
        [Route("edit")]

        public IActionResult EventStyleEdit(EventStyleDto eventStyleDto)
        {
            return View("EventStyleEdit", eventStyleDto);
        }

        [HttpPost]
        [Route("edit-style")]
        public async Task<IActionResult> EditStyle(EventStyleDto eventStyleDto)
        {
            await eventStyleService.EditAsync(eventStyleDto);
            if (ModelState.IsValid)
            {
                // TODO: to nameof of action
                return RedirectToAction("EventStyles");
            }

            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("event-style-preview")]
        public IActionResult EventStylePreview()
        {
            return View(new EventStyleDto());
        }

        [HttpPost]
        [Route("add-style")]
        public async Task<IActionResult> AddStyle(EventStyleDto eventStyleDto)
        {
            await eventStyleService.AddAsync(eventStyleDto);
            if (ModelState.IsValid)
            {
                return RedirectToAction("EventStyles");
            }

            // TODO: use propeper status code
            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult DeletePopUpPartial(EventStyleDto eventStyleDto)
        {
            return PartialView("_DeletePopUpPartial", eventStyleDto);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteStyle(int styleId)
        {
            await eventStyleService.DeleteAsync(styleId);
            if (ModelState.IsValid)
            {
                // TODO: Use proper status code
                return new StatusCodeResult(201);
            }

            // TODO: Use proper status code
            return new StatusCodeResult(500);
        }
    }
}
