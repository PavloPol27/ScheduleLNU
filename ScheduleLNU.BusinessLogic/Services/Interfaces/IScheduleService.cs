using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(int studentId);

        Task AddSchedulesAsync(int studentId, string schedule);
    }
}
