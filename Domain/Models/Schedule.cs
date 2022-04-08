using System.Collections.Generic;

namespace Domain.Models
{
    public class Schedule
    {
        public string Title { get; set; } = string.Empty;


        public Student Student { get; set; }


        public List<Event> Events { get; set; } = new List<Event>();
    }
}
