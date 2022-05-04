using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICookieService cookieService;
        private readonly IRepository<Student> studentRepository;
        private readonly UserManager<Student> signInManager;

        public LoginService(ICookieService injectedCookieService,
                                IRepository<Student> injectedStudentRepository,
                                UserManager<Student> injectedSignInManager)
        {
            cookieService = injectedCookieService;
            studentRepository = injectedStudentRepository;
            signInManager = injectedSignInManager;
        }

        public async Task<bool> LogInAsync(LoginDto loginDto)
        {
            var student = await studentRepository.SelectAsync(x => x.Email == loginDto.Email);
            var result = await signInManager.CheckPasswordAsync(student, loginDto.Password);

            if (result)
            {
                await cookieService.SetCookies(("studentId", student.Id));
                return true;
            }

            return false;
        }
    }
}
