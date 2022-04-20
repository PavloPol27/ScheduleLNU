﻿using System.Collections.Generic;
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
        public async Task<IActionResult> DeleteSchedule(int studentId, int scheduleId)
        {
            bool deleteResult = await this.scheduleService.DeleteScheduleAsync(studentId, scheduleId);
            return RedirectToAction("View", new { id = 228 });;
        }
    }
}
