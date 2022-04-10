<<<<<<< HEAD:Domain/DataContext.cs
﻿using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Domain
=======
﻿using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/DataContext.cs
{
    public class DataContext : DbContext
    {
        public Repository<Event> Events { get; set; }


        public Repository<Schedule> Schedules { get; set; }


        public Repository<Student> Students { get; set; }


        public Repository<Theme> Themes { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
            Events = new Repository<Event>(this);
            Students = new Repository<Student>(this);
            Themes = new Repository<Theme>(this);
            Schedules = new Repository<Schedule>(this);
        }
    }
}
