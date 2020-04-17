namespace MedAppDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string ZipCode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
