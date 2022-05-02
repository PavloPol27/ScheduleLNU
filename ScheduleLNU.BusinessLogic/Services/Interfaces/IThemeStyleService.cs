using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IThemeStyleService
    {
        public Task<IEnumerable<ThemeDTO>> GetAllThemesAsync(int studentId);

        Task Insert(int studentID, Theme theme);

        Task Edit(int studentID, Theme theme);

        Task<Theme> ViewTheme(int studentID, int themeId);
    }
}
