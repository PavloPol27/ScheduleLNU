using ScheduleLNU.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IStylizationService
    {
        public Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(uint studentId);

        public Task<IEnumerable<Theme>> GetAllThemesAsync(uint studentID);
    }
}
