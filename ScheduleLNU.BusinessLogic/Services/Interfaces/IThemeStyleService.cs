using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IThemeStyleService
    {
        public Task<IEnumerable<ThemeDTO>> GetAllThemesAsync(string studentId);

        Task Insert(string studentID, Theme theme);

        Task Edit(Theme theme);

        Task<Theme> ViewTheme(string studentId, int themeId);
    }
}
