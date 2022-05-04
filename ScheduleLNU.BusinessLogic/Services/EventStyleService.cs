using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleLNU.BusinessLogic.DTOs;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class EventStyleService : IEventStyleService
    {
        private readonly IRepository<EventStyle> eventStyleRepository;

        public EventStyleService(IRepository<EventStyle> eventStyleRepository, IRepository<Student> studentRepository)
        {
            this.eventStyleRepository = eventStyleRepository;
        }

        public async Task AddAsync(EventStyleDto eventStyleDto)
        {
            await eventStyleRepository.InsertAsync(
                new EventStyle
                {
                    Title = eventStyleDto.Title,
                    ForeColor = eventStyleDto.ForeColor,
                    BackColor = eventStyleDto.BackColor,
                    StudentId = eventStyleDto.StudentId
                });
        }

        public async Task DeleteAsync(string studentId, int eventId)
        {
            var eventStyle = await eventStyleRepository.SelectAsync(s => s.Id == eventId && s.StudentId == studentId);
            await eventStyleRepository.DeleteAsync(eventStyle);
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

        public async Task<IEnumerable<EventStyleDto>> GetAllAsync(string studentId)
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
