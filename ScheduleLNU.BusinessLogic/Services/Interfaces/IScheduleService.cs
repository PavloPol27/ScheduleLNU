using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
       Task<IEnumerable<ScheduleDto>> GetAllAsync();

       Task<bool> DeleteAsync(int scheduleId);

       Task<bool> AddAsync(string scheduleTitle);

       Task<bool> EditAsync(int scheduleId, string scheduleTitle);
    }
}
