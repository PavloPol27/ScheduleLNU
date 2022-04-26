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

        public ThemeStyleService(IRepository<Student> injectedStudentRepository,
            IRepository<Theme> injectedThemeRepository)
        {
            studentRepository = injectedStudentRepository;
            themeRepository = injectedThemeRepository;
        }

        public async Task<IEnumerable<ThemeDTO>> GetAllThemesAsync(int studentId)
        {
            var studentRecord = await studentRepository
                .SelectAsync(s => s.Id == studentId, s => s.Themes, s => s.SelectedTheme);
            return studentRecord.Themes
                .Select(t => new ThemeDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsSelected = t.Id == studentRecord.SelectedTheme?.Id
                });
        }

        public async Task<Theme> ViewTheme(int studentId, int themeID)
        {
            var studentRecord = await studentRepository.SelectAsync(s => s.Id == studentId, s => s.Themes);
            var theme = studentRecord.Themes.FirstOrDefault(t => t.Id == themeID);

            if (theme is null)
            {
                throw new NullReferenceException($"Theme {themeID} is not fount");
            }

            return theme;
        }

        public async Task Edit(int studentId, Theme theme)
        {
            await themeRepository.UpdateAsync(theme);
        }

        public async Task Insert(int studentId, Theme theme)
        {
            var studentRecord = await studentRepository.SelectAsync(s => s.Id == studentId, s => s.Themes);
            studentRecord.Themes.Add(theme);
            await studentRepository.UpdateAsync(studentRecord);
        }
    }
}
