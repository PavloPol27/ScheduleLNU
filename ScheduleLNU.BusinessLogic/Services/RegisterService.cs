using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly ICookieService cookieService;
        private readonly UserManager<Student> userManager;

        public RegisterService(ICookieService injectedCookieService,
                                UserManager<Student> injectedUserManager)
        {
            cookieService = injectedCookieService;
            userManager = injectedUserManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var student = new Student
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                NormalizedUserName = $"{registerDto.FirstName} {registerDto.LastName}"
            };

            var result = await userManager.CreateAsync(student, registerDto.Password);

            if (result.Succeeded)
            {
                await cookieService.SetCookies(("studentId", student.Id));
            }

            return result;
        }
    }
}
