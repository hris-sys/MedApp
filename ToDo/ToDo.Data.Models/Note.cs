using System;
using System.Collections.Generic;

namespace ToDo.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ExpiredOn { get; set; }

        public string Description { get; set; }

        public bool? IsDeleted { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
