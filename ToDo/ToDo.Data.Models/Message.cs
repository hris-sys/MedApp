using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.Models
{
    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }

        public bool IsDeleted { get; set; }
    }
}
