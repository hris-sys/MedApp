using System.Collections.Generic;

namespace ToDo.Data.Models
{
    public class City
    {
        public City()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}