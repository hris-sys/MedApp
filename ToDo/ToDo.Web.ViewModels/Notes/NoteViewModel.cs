using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Web.ViewModels.Notes
{
    public class NoteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime ExpiredOn { get; set; }
    }
}
