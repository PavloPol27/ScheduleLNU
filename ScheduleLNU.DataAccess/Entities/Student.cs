using System.Collections.Generic;

namespace ScheduleLNU.DataAccess.Entities
{
    public class Student
    {
        public uint Id { get; set; }


        public string EmailAddress { get; set; } = string.Empty;

        
        public string PhoneNumber { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public bool IsNotifiable { get; set; }


        public Theme SelectedTheme { get; set; }

        
        public List<Theme> Themes { get; set; }
    }
}
