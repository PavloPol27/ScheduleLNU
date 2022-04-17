using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace ScheduleLNU.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Theme> Themes { get; set; }
        
        public DbSet<EventStyle> EventsStyles { get; set; }

        public DbSet<Link> Links { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
