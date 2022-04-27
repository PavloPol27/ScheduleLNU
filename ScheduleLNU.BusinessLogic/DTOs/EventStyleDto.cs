using Microsoft.AspNetCore.Mvc;

namespace ScheduleLNU.BusinessLogic.DTOs
{
    public class EventStyleDto
    {
        [BindProperty]
        public int Id { get; set; }

        public string Title { get; set; }

        public string ForeColor { get; set; }

        public string BackColor { get; set; }

        [BindProperty]
        public int StudentId { get; set; }
    }
}
