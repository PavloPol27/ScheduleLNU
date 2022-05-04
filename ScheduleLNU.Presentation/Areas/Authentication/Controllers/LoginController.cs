﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.Presentation.Areas.Authentication.Controllers
{
    [Area("authentication")]
    [Route("[area]/login")]
    public class LoginController : Controller
    {
        private readonly IAuthService authService;

        private readonly SignInManager<Student> signInManager;

        public LoginController(IAuthService authService, SignInManager<Student> signInManager)
        {
            this.authService = authService;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("view", "Schedules");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(loginDto);
        }

        [HttpGet]
        [Route("forgot-password")]
        public ActionResult ForgotPasswordForm()
        {
            return View();
        }

        [HttpPost]
        [Route("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            await authService.SendResetTokenAsync(forgotPasswordDto.Email);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }

        [HttpGet]
        [Route("reset-password")]
        public ActionResult ResetPasswordForm(string email)
        {
            Debug.WriteLine(email);
            email = email.Replace("token=", "");
            string[] parameters = email.Split('?');
            var resetPasswordDto = new ResetPasswordDto { Email = parameters[0], Token = parameters[1] };
            return View(resetPasswordDto);
        }

        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            await authService.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.Token, resetPasswordDto.NewPassword, resetPasswordDto.ConfirmedPassword);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            return new StatusCodeResult(500);
        }
    }
}
