using System.Collections.Generic;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Student : BaseEntity
    {
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsNotifiable { get; set; }

        public Theme SelectedTheme { get; set; }

        public List<Theme> Themes { get; set; }

        public List<EventStyle> EventStyles { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
