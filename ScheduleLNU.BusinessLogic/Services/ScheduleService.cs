using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> scheduleRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(uint studentId)
        {
            return (await this.scheduleRepository
                .SelectAllAsync(x => x.Student.Id == studentId))
                .Select(x => new ScheduleDto { Id = x.Id, Title = x.Title });
        }
    }
}
