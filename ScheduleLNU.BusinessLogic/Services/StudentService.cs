﻿using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }
    }
}
