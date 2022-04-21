using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class StylizationService : IThemeStyleService
    {
        private readonly IRepository<Student> studentRepository;

        public StylizationService(IRepository<Student> injectedStudentRepository)
        {
            studentRepository = injectedStudentRepository;
        }

        public async Task<IEnumerable<ThemeDTO>> GetAllThemesAsync(int studentID)
        {
            var studentRecord = await studentRepository
                    .SelectWithIncludeAsync(s => s.Id == studentID, s => s.Themes, s => s.SelectedTheme);

            return studentRecord.Themes
                .Select(t => new ThemeDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsSelected = t.Id == studentRecord.SelectedTheme.Id
                });
        }

        public async Task Insert(int studentId, Theme theme)
        {
            var student = await studentRepository.SelectWithIncludeAsync(s => s.Id == studentId, p => p.Themes);
            student.Themes.Add(theme);
            await studentRepository.UpdateAsync(student);
        }
    }
}
