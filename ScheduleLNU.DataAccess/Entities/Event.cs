using System;
using System.Collections.Generic;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Event
    {
        public uint Id { get; set; }

        
        public string Title { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;


        public string Place { get; set; } = string.Empty;


        public DateTime StartTime { get; set; }

        
        public DateTime EndTime { get; set; }


        public Theme Theme { get; set; }


        public List<Link> Links { get; set; }
    }
}
