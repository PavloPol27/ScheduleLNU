using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Extensions;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("schedules")]
    [Authorize]
    public class SchedulesController : Controller
    {
        private readonly IScheduleService scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewSchedles()
        {
            IEnumerable<ScheduleDto> resList = await scheduleService.GetAllAsync();
            return View(resList);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int scheduleId)
        {
            bool deleteResult = await scheduleService.DeleteAsync(scheduleId);
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
            bool addResult = await scheduleService.AddAsync(scheduleTitle);
            if (ModelState.IsValid && addResult)
            {
                return StatusCode(200);
            }

            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddPopup()
        {
            return PartialView("_AddPopUpPartial", new ScheduleDto());
        }

        [Route("edit")]
        public async Task<IActionResult> Edit(int scheduleId, string title)
        {
            await scheduleService.EditAsync(scheduleId, title);
            return StatusCode(200);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult EditPopup(ScheduleDto scheduleDto)
        {
            return PartialView("_EditPopUpPartial", scheduleDto);
        }
    }
}
