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

        public async Task<IActionResult> View(int id)
        {
            IEnumerable<ScheduleDto> resList = await this.scheduleService.GetSchedulesAsync(id);

            return View(resList);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSchedule(string title)
        {
            if (ModelState.IsValid)
            {
                await this.scheduleService.AddSchedulesAsync(27, title);
                return RedirectToAction("View");
            }

            return new StatusCodeResult(400);
        }
    }
}
