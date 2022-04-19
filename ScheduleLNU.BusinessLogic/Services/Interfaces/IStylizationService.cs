using ScheduleLNU.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services.Interfaces
{
    public interface IStylizationService
    {
        public Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(uint studentID);

        public Task<IEnumerable<Theme>> GetAllThemesAsync(uint studentID);
    }
}
