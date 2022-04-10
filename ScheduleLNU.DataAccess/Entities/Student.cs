<<<<<<< HEAD:Domain/Models/Student.cs
﻿namespace Domain.Models
=======
﻿namespace DataAccess.Entities
>>>>>>> create_layered_architecture:ScheduleLNU.DataAccess/Entities/Student.cs
{
    public class Student
    {
        public string EmailAddress { get; set; } = string.Empty;

        
        public string PhoneNumber { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public bool IsNotifiable { get; set; }


        public Theme SelectedTheme { get; set; }
    }
}
