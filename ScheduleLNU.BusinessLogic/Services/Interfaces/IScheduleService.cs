using ScheduleLNU.BusinessLogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
       Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(uint studentId);
    }
}
