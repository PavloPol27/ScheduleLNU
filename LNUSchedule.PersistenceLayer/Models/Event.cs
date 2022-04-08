﻿using System.ComponentModel.DataAnnotations;

namespace LNUSchedule.PersistenceLayer.Models
{
    public class Event
    {
        [Key]
        public string Title { get; set; } = string.Empty;


        [MaxLength(100)]
        public string Descryption { get; set; } = string.Empty;


        public string Place { get; set; } = string.Empty;


        public DateTime StartTime { get; set; }

        
        public DateTime EndTime { get; set; }


        public List<string> Links { get; set; } = new List<string>();
    }
}
