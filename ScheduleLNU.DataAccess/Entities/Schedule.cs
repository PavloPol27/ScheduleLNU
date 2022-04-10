using System.Collections.Generic;

<<<<<<< HEAD:Domain/Models/Schedule.cs
namespace Domain.Models
=======
namespace DataAccess.Entities
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/Entities/Schedule.cs
{
    public class Schedule
    {
        public string Title { get; set; } = string.Empty;


        public Student Student { get; set; }


        public List<Event> Events { get; set; } = new List<Event>();
    }
}
