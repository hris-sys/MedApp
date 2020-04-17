﻿namespace MedAppDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public Role()
        {
            this.UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
