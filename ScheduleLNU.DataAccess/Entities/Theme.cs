using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:Domain/Models/Theme.cs
namespace Domain.Models
=======
namespace DataAccess.Entities
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/Entities/Theme.cs
{
    public class Theme
    {
        [Key]
        public string Title { get; set; } = string.Empty;


        public string ForeColor { get; set; } = string.Empty;


        public string BackColor { get; set; } = string.Empty;


        public string Font { get; set; } = string.Empty;

        
        public int FontSize { get; set; } = 14;
    }
}
