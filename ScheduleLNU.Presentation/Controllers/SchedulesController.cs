using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("schedules")]
    [Authorize]
    public class SchedulesController : Controller
    {
        private readonly IScheduleService scheduleService;
        private readonly ILogger<SchedulesController> logger;

        public SchedulesController(ILogger<SchedulesController> logger,
            IScheduleService scheduleService)
        {
            this.logger = logger;
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> View(int studentId)
        {
            IEnumerable<ScheduleDto> resList = await scheduleService.GetAllAsync(studentId);
            return View(resList);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int studentId, int scheduleId)
        {
            bool deleteResult = await scheduleService.DeleteAsync(studentId, scheduleId);
            return deleteResult ? StatusCode(204) : StatusCode(400);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult DeletePopup(ScheduleDto scheduleDto)
        {
            return PartialView("_DeletePopUpPartial", scheduleDto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(string scheduleTitle)
        {
            var studentId = 228;
            bool addResult = await scheduleService.AddAsync(studentId, scheduleTitle);
            logger.LogInformation("Student added schedule {sheduleTitle} to the list of schedules",
                scheduleTitle);
            if (ModelState.IsValid && addResult)
            {
                return RedirectToAction("View", new { studentId = studentId });
            }

            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddPopup()
        {
            logger.LogInformation("Student opened add schedule popup");
            return PartialView("_AddPopUpPartial", new ScheduleDto());
        }

        [Route("edit")]
        public async Task<IActionResult> Edit(int scheduleId, string title)
        {
            var studentId = 228;
            await scheduleService.EditAsync(studentId, scheduleId, title);
            logger.LogInformation("Student changed schedule {scheduleId} title to {sheduleTitle}",
                scheduleId, title);
            return StatusCode(200);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult EditPopup(ScheduleDto scheduleDto)
        {
            logger.LogInformation("Student opened edit schedule popup");
            return PartialView("_EditPopUpPartial", scheduleDto);
        }
    }
}
