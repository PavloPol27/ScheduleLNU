using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class ThemeStyleService : IThemeStyleService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IRepository<Theme> themeRepository;

        private readonly ICookieService cookieService;

        public ThemeStyleService(IRepository<Student> injectedStudentRepository,
            IRepository<Theme> injectedThemeRepository,
            ICookieService injectedCookieService)
        {
            studentRepository = injectedStudentRepository;
            themeRepository = injectedThemeRepository;
            cookieService = injectedCookieService;
        }

        public async Task<IEnumerable<ThemeDTO>> GetAllThemesAsync()
        {
            var studentId = cookieService.GetStudentId();
            var studentRecord = await studentRepository
                .SelectAsync(s => s.Id == studentId, s => s.Themes, s => s.SelectedTheme);
            return studentRecord?.Themes
                .Select(t => new ThemeDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsSelected = t.Id == studentRecord.SelectedTheme?.Id
                }) ?? Array.Empty<ThemeDTO>();
        }

        public async Task<Theme> ViewTheme(int themeID)
        {
            var studentId = cookieService.GetStudentId();
            var studentRecord = await studentRepository.SelectAsync(s => s.Id.Equals(studentId), s => s.Themes);
            var theme = studentRecord.Themes.FirstOrDefault(t => t.Id == themeID);

            return theme;
        }

        public async Task Edit(Theme theme)
        {
            await themeRepository.UpdateAsync(theme);
        }

        public async Task Insert(Theme theme)
        {
            var studentId = cookieService.GetStudentId();
            var studentRecord = await studentRepository.SelectAsync(s => s.Id.Equals(studentId), s => s.Themes);
            studentRecord.Themes.Add(theme);
            await studentRepository.UpdateAsync(studentRecord);
        }
    }
}
