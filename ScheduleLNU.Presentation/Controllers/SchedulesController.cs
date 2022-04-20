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
            IEnumerable<ScheduleDto> resList = await scheduleService.GetSchedulesAsync(id);

            return View(resList);
        }

        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> Edit(int id, string title)
        {
            bool editResult = await scheduleService
                .Edit(new ScheduleDto { Id = id, Title = title });

            if (editResult && ModelState.IsValid)
            {
                return RedirectToAction("View");
            }

            return new StatusCodeResult(500);
        }
    }
}
