using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IThemeStyleService
    {
        public Task<IEnumerable<ThemeDTO>> GetAllThemesAsync(int studentID);

        Task Insert(int studentId, Theme theme);
    }
}
