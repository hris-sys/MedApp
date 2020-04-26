using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.Models
{
    public class Message
    {
        public Message()
        {
            this.ApplicationUserMessages = new HashSet<ApplicationUserMessage>();

            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<ApplicationUserMessage> ApplicationUserMessages { get; set; }
    }
}
