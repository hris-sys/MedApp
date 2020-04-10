using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedAppDataAccess.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.ActiveIngedients = new HashSet<ActiveIngedient>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(15)]
        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<ActiveIngedient> ActiveIngedients { get; set; }
    }
}
