using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Event
    {
        public uint Id { get; set; }

        
        public string Title { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }


        public string Place { get; set; }


        public DateTime StartTime { get; set; }

        
        public DateTime EndTime { get; set; }

        
        public EventStyle Style { get; set; }


        public List<Link> Links { get; set; }
    }
}
