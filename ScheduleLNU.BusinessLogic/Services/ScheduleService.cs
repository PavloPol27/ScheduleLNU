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
        private readonly IRepository<Student> studentRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository, IRepository<Student> studentRepository)
        {
            this.scheduleRepository = scheduleRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesAsync(int studentId)
        {
            return (await scheduleRepository
                .SelectAllAsync(x => x.Student.Id == studentId))
                .Select(x => new ScheduleDto { Id = x.Id, Title = x.Title });
        }

        public async Task AddSchedulesAsync(int studentId, string title)
        {
            var student = await studentRepository.SelectAsync(s => s.Id == studentId);
            await this.scheduleRepository.InsertAsync(new Schedule { Title = title, Student = student });
        }
    }
}
