namespace ScheduleLNU.DataAccess.Entities
{
    public class Theme : BaseEntity
    {
        public string Title { get; set; }

        public string ForeColor { get; set; }

        public string BackColor { get; set; }

        public string Font { get; set; }

        public int FontSize { get; set; }
    }
}
