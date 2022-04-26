using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IEventStyleService
    {
        Task<IEnumerable<EventStyleDto>> GetAllAsync(int studentId);

        Task<bool> DeleteAsync(int studentId, int scheduleId);

        Task<bool> AddAsync(int studentId, string scheduleTitle);

        Task<bool> EditAsync(int studentId, int scheduleId, string scheduleTitle);
    }
}