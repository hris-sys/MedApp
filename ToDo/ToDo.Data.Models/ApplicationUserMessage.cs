using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.Models
{
    public class ApplicationUserMessage
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string MessageId { get; set; }

        public Message Message { get; set; }
    }
}
