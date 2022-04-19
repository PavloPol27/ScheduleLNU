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
        private readonly IRepository<Student> studentRepository;

        private readonly ILogger<StylizationService> logger;

        public StylizationService(IRepository<Student> injectedStudentRepository, ILogger<StylizationService> injectedLogger)
        {
            studentRepository = injectedStudentRepository;
            logger = injectedLogger;
        }

        public async Task<IEnumerable<EventStyle>> GetAllEventStylesAsync(int studentID)
        {
            return (await studentRepository
                .SelectAllByIdWithIncludeAsync(studentID, s => s.EventStyles))
                .SelectMany(s => s.EventStyles);
        }

        public async Task<IEnumerable<Theme>> GetAllThemesAsync(int studentID)
        {
            return (await studentRepository
                    .SelectAllByIdWithIncludeAsync(studentID, s => s.Themes))
                    .SelectMany(s => s.Themes);
        }

        public async Task Insert(int studentId, Theme theme)
        {
            try
            {
                var student = (await studentRepository.SelectAllByIdWithIncludeAsync(studentId, p => p.Themes)).FirstOrDefault();
                student.Themes.Add(theme);
                await studentRepository.UpdateAsync(student);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
