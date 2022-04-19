using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IStylizationService
    {
        public Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(int studentID);

        public Task<IEnumerable<Theme>> GetAllThemesAsync(int studentID);

        Task Insert(int studentId, Theme theme);
    }
}
