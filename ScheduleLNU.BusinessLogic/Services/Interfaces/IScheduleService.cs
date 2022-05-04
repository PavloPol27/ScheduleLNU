using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
       Task<IEnumerable<ScheduleDto>> GetAllAsync(string studentId);

       Task<bool> DeleteAsync(string studentId, int scheduleId);

       Task<bool> AddAsync(string studentId, string scheduleTitle);

       Task<bool> EditAsync(string studentId, int scheduleId, string scheduleTitle);
    }
}
