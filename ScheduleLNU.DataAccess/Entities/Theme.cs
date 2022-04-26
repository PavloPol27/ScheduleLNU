using System.ComponentModel.DataAnnotations;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Theme : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = "New theme";

        public string ForeColor { get; set; } = $"#000000";

        public string BackColor { get; set; } = $"#FFFFFF";

        public string Font { get; set; } = "Arial";

        public int FontSize { get; set; } = 16;
    }
}
