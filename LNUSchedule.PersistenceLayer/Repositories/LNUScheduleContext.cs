using LNUSchedule.PersistenceLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LNUSchedule.PersistenceLayer.Repositories
{
    public class LNUScheduleContext : DbContext
    {
        public Repository<Event> Events { get; set; }


        public Repository<Schedule> Schedules { get; set; }


        public Repository<Student> Students { get; set; }

        
        public Repository<Theme> Themes { get; set; }


        public LNUScheduleContext(DbContextOptions options) : base(options)
        {
            Events = new Repository<Event>(this);
            Students = new Repository<Student>(this);
            Themes = new Repository<Theme>(this);
            Schedules = new Repository<Schedule>(this);
        }
    }
}
