using Microsoft.AspNetCore.Identity;

namespace ScheduleLNU.DataAccess.Entities
{
    public class StudentAspIdentity : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
