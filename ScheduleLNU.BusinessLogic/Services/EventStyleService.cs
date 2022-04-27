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
    public class EventStyleService : IEventStyleService
    {
        private readonly IRepository<EventStyle> eventStyleRepository;

        public EventStyleService(IRepository<EventStyle> eventStyleRepository)
        {
            this.eventStyleRepository = eventStyleRepository;
        }

        public Task<bool> AddAsync(int studentId, string scheduleTitle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int studentId, int scheduleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditAsync(EventStyleDto eventStyle)
        {
            await eventStyleRepository.UpdateAsync(
                new EventStyle
                {
                    Id = eventStyle.Id,
                    Title = eventStyle.Title,
                    ForeColor = eventStyle.ForeColor,
                    BackColor = eventStyle.BackColor,
                    StudentId = eventStyle.StudentId
                });
            return true;
        }

        public async Task<IEnumerable<EventStyleDto>> GetAllAsync(int studentId)
        {
            return (await eventStyleRepository
                .SelectAllAsync(x => x.StudentId == studentId))
                .Select(x => new EventStyleDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    BackColor = x.BackColor,
                    ForeColor = x.ForeColor,
                    StudentId = studentId
                });
        }
    }
}
