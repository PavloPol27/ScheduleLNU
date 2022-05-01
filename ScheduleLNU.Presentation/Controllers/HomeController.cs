﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;

namespace ScheduleLNU.Presentation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IStudentService studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            this.logger = logger;
            this.studentService = studentService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public IActionResult Index(int studentId)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30)
            };
            Response.Cookies.Append("studentId", studentId.ToString(), options);
            return Redirect("~/settings/themes");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
