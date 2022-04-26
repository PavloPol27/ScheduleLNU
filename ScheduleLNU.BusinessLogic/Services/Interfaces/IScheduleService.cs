using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
       Task<IEnumerable<ScheduleDto>> GetAllAsync(int studentId);

       Task<bool> DeleteAsync(int studentId, int scheduleId);

       Task<bool> AddAsync(int studentId, string scheduleTitle);

       Task<bool> EditAsync(int studentId, int scheduleId, string scheduleTitle);
    }
}
