using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Web.ViewModels.Notes
{
    public class NoteViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
