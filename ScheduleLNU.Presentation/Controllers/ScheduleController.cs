﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("schedules/")]
    public class ScheduleController : Controller
    {
        private IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync(uint id)
        {
            string result = "";
            IEnumerable<ScheduleDto> resList = await this.scheduleService.GetSchedulesAsync(id);

            foreach (var res in resList)
            {
                result += res.Title + "\n";
            }

            return View("Schedules", result);
        }
    }
}
