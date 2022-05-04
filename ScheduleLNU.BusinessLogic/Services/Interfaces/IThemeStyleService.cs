using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IThemeStyleService
    {
        public Task<IEnumerable<ThemeDto>> GetAllThemesAsync();

        Task Insert(Theme theme);

        Task Edit(Theme theme);

        Task<Theme> ViewTheme(int themeId);
    }
}
