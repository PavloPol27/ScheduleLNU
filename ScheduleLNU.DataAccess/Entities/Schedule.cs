using System.Collections.Generic;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Schedule : BaseEntity
    {
        public string Title { get; set; }

        public Student Student { get; set; }

        public List<Event> Events { get; set; }
    }
}
