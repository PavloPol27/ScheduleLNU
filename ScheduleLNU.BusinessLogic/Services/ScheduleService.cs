using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> scheduleRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(int studentId)
        {
            return (await scheduleRepository
                .SelectAllAsync(x => x.Student.Id == studentId))
                .Select(x => new ScheduleDto { Id = x.Id, Title = x.Title });
        }
    }
}
