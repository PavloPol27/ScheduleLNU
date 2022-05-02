﻿using ScheduleLNU.BusinessLogic.Services.Interfaces;
using ScheduleLNU.DataAccess.Contexts;

namespace ScheduleLNU.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext context;

        public StudentService(DataContext context)
        {
            this.context = context;
        }
    }
}
