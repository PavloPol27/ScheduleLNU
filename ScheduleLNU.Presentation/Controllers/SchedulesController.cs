using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("schedules")]
    public class SchedulesController : Controller
    {
        private readonly IScheduleService scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            IEnumerable<ScheduleDto> resList = await scheduleService.GetAllAsync(id);

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
            if (ModelState.IsValid && addResult)
            {
                return RedirectToAction("View", new { id = studentId });
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
        public async Task<IActionResult> Edit(int studentId, int scheduleId, string title)
        {
            bool editResult = await scheduleService.EditAsync(studentId, scheduleId, title);

            if (editResult && ModelState.IsValid)
            {
                return RedirectToAction("View", new { id = studentId });
            }

            return new StatusCodeResult(500);
        }
    }
}
