namespace MedApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Genders Gender { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}
