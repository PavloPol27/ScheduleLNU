using Microsoft.Extensions.Logging;
using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class ThemeService : IStylizationService
    {
        private readonly Repository<Student> studentRepository;

        private ILogger<ThemeService> logger;

        public ThemeService(ILogger<ThemeService> injectedLogger,
            Repository<Student> injectedStudentRepository)
        {
            logger = injectedLogger;
            studentRepository = injectedStudentRepository;
        }

        public async Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(uint studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Theme>> GetAllThemesAsync(uint studentID)
        {
            throw new NotImplementedException();
        }
    }
}
