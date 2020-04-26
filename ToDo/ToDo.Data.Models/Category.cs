using System.Collections.Generic;

namespace ToDo.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
