using ScheduleLNU.DataAccess.Entities;

namespace ScheduleLNU.BusinessLogic.DTOs
{
    public class ThemeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = "New theme";

        public string ForeColor { get; set; } = $"#000000";

        public string BackColor { get; set; } = $"#FFFFFF";

        public string Font { get; set; } = "Arial";

        public int FontSize { get; set; } = 16;

        public bool IsSelected { get; set; } = false;

        public static implicit operator Theme(ThemeDTO themeDTO)
        {
            return new Theme()
            {
                Id = themeDTO.Id,
                Title = themeDTO.Title,
                ForeColor = themeDTO.ForeColor,
                Font = themeDTO.Font,
                FontSize = themeDTO.FontSize
            };
        }
    }
}
