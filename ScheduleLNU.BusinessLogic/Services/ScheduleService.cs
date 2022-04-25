using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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

        public async Task<IEnumerable<ScheduleDto>> GetAllAsync(int studentId)
        {
            return (await scheduleRepository
                .SelectAllAsync(x => x.Student.Id == studentId))
                .Select(x => new ScheduleDto { Id = x.Id, Title = x.Title, StudentId = studentId});
        }

        public async Task<bool> DeleteAsync(int studentId, int scheduleId)
        {
            try
            {
                Schedule schedule = (await scheduleRepository.SelectAllWithIncludeAsync((schedule) =>
                schedule.Id == scheduleId && schedule.Student.Id == studentId,
                (entity) => entity.Student)).FirstOrDefault();
                await scheduleRepository.DeleteAsync(schedule);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(int studentId, string scheduleTitle)
        {
            try
            {
                await scheduleRepository.InsertAsync(new Schedule { Title = scheduleTitle, StudentId = studentId });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(int studentId, int scheduleId, string scheduleTitle)
        {
            try
            {
                await scheduleRepository.UpdateAsync(
                    new Schedule { Id = scheduleId, Title = scheduleTitle, StudentId = studentId });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
