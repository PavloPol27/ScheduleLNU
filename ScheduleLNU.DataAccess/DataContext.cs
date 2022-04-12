using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace ScheduleLNU.DataAccess
{
    public class DataContext : DbContext
    {
        public Repository<Event> Events { get; set; }


        public Repository<Schedule> Schedules { get; set; }


        public Repository<Student> Students { get; set; }


        public Repository<Theme> Themes { get; set; }

        
        public Repository<EventStyle> EventsStyles { get; set; }


        public Repository<Link> Links { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
            Events = new Repository<Event>(this);
            Students = new Repository<Student>(this);
            Themes = new Repository<Theme>(this);
            EventsStyles = new Repository<EventStyle>(this);
            Schedules = new Repository<Schedule>(this);
            Links = new Repository<Link>(this);
        }
    }
}