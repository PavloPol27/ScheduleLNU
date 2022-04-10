namespace ScheduleLNU.DataAccess.Entities
{
    public class Theme
    {
        public uint Id { get; set; }

        
        public string Title { get; set; } = string.Empty;


        public string ForeColor { get; set; } = string.Empty;


        public string BackColor { get; set; } = string.Empty;


        public string Font { get; set; } = string.Empty;

        
        public int FontSize { get; set; } = 16;
    }
}
