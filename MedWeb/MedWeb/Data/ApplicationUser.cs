using Microsoft.AspNetCore.Identity;

namespace MedWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public bool Gender { get; set; }

        public int? CityId { get; set; }

        public City City { get; set; }
    }
}
