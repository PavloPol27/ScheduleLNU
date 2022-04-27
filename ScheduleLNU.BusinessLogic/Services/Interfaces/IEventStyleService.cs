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

        Task AddAsync(EventStyleDto eventStyleDto);

        Task<bool> EditAsync(EventStyleDto eventStyle);
    }
}