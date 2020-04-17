using System.Collections.Generic;

namespace MedAppDataAccess.Models
{
    public class User
    {
        public User()
        {
            this.UserRoles = new HashSet<UserRoles>();

            this.Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
