using System.ComponentModel.DataAnnotations;

namespace MedAppDataAccess.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(8)]
        public string ZipCode { get; set; }
    }
}
