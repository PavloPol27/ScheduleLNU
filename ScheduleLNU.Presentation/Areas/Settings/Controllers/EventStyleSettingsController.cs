﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Settings.Controllers
{
    [Area("settings")]
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

        [HttpGet]
        [Route("edit")]
        public IActionResult EventStyleEdit(int styleId, int studentId, string foreColor, string backColor, string title)
        {
            var eventStyleDto = new EventStyleDto
            {
                Id = styleId,
                StudentId = studentId,
                ForeColor = foreColor,
                BackColor = backColor,
                Title = title
            };

            logger.LogInformation("Student tries to edit event style {styleId}", styleId);
            return View("EventStyleEdit", eventStyleDto);
        }

        [HttpPost]
        [Route("edit-style")]
        public async Task<IActionResult> EditStyle(EventStyleDto eventStyleDto)
        {
            await eventStyleService.EditAsync(eventStyleDto);
            if (ModelState.IsValid)
            {
                logger.LogInformation("Student updated event style {eventStyleId}: title - {eventStyleTitle}," +
                    "fore color - {eventStyleForeColor} and back color - {eventStyleBackColor} to the list of event styles",
                    eventStyleDto.Id, eventStyleDto.Title, eventStyleDto.ForeColor, eventStyleDto.BackColor);
                return RedirectToAction("EventStyles", new { studentId = eventStyleDto.StudentId });
            }

            logger.LogInformation("Student failed to edit event style");
            return new StatusCodeResult(500);
        }
        
        [HttpGet]
        [Route("event-style-preview")]
        public IActionResult EventStylePreview(int studentId)
        {
            logger.LogInformation("Student {studentID} creates new event style", studentId);

            return View(new EventStyleDto());
        }

        [HttpPost]
        [Route("add-style")]
        public async Task<IActionResult> AddStyle(EventStyleDto eventStyleDto)
        {
            eventStyleDto.StudentId = 228;
            await eventStyleService.AddAsync(eventStyleDto);
            if (ModelState.IsValid)
            {
                logger.LogInformation("Student added new event style with a title - {eventStyleTitle}," +
                    "fore color - {eventStyleForeColor} and back color - {eventStyleBackColor}" +
                    " to the list of event styles", eventStyleDto.Title, eventStyleDto.ForeColor, eventStyleDto.BackColor);
                return RedirectToAction("EventStyles", new { studentId = eventStyleDto.StudentId });
            }

            logger.LogInformation("Student failed to add new event style");
            return new StatusCodeResult(500);
        }
    }
}
