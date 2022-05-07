using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleLNU.BusinessLogic.DTOs
{
    public class RegisterDto
    {
        // For the sake of view, change it to your preferences.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
