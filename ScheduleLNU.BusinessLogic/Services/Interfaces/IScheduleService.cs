using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
       Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(int studentId);

       Task<bool> DeleteScheduleAsync(int studentId, int scheduleId);
    }
}
