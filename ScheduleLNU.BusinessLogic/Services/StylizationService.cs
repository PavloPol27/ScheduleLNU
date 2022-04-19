using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class StylizationService : IStylizationService
    {
        private readonly Repository<Student> studentRepository;

        private ILogger<StylizationService> logger;

        public StylizationService(ILogger<StylizationService> injectedLogger,
            Repository<Student> injectedStudentRepository)
        {
            logger = injectedLogger;
            studentRepository = injectedStudentRepository;
        }

        public async Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(uint studentID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Theme>> GetAllThemesAsync(uint studentID)
        {
            return (IEnumerable<Theme>)(await studentRepository
                    .SelectAllByIdWithIncludeAsync(studentID, s => s.Themes))
                    .Select(s => s.Themes);
        }
    }
}
