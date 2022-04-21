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
        public async Task<IActionResult> DeleteSchedule(int studentId, int scheduleId)
        {
            bool deleteResult = await scheduleService.DeleteAsync(studentId, scheduleId);
            if (deleteResult)
            {
                return RedirectToAction("View", new { id = studentId });
            }

            return new StatusCodeResult(400);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSchedule(int studentId, string scheduleTitle)
        {
            bool addResult = await scheduleService.AddAsync(studentId, scheduleTitle);
            if (ModelState.IsValid && addResult)
            {
                return RedirectToAction("View", new { id = studentId });
            }

            return new StatusCodeResult(500);
        }

        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> Edit(int studentId, int scheduleId, string title)
        {
            bool editResult = await scheduleService.EditAsync(studentId, scheduleId, title);

            if (editResult && ModelState.IsValid)
            {
                return RedirectToAction("View");
            }

            return new StatusCodeResult(500);
        }
    }
}
