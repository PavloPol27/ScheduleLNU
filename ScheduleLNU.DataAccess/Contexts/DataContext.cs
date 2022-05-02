using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.DataAccess.Contexts
{
    public class DataContext : IdentityDbContext<StudentAspIdentity>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<EventStyle> EventsStyles { get; set; }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
