using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:Domain/Models/Event.cs
namespace Domain.Models
=======
namespace DataAccess.Entities
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/Entities/Event.cs
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


        public Theme Theme { get; set; }


        public List<string> Links { get; set; } = new List<string>();
    }
}
