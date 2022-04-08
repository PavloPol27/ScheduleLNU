﻿using System.ComponentModel.DataAnnotations;

namespace LNUSchedule.PersistenceLayer.Models
{
    public class Theme : IEntity
    {
        [Key]
        public string Title { get; set; } = string.Empty;


        public string ForeColor { get; set; } = string.Empty;


        public string BackColor { get; set; } = string.Empty;


        public string Font { get; set; } = string.Empty;

        
        public int FontSize { get; set; } = 14;
    }
}
