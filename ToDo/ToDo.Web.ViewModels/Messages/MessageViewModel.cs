using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.Web.ViewModels.Messages
{
    public class MessageViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Sender")]
        public string SenderUserName { get; set; }

        [Display(Name = "Receiver")]
        public string ReceiverUserName { get; set; }

        [Display(Name = "Sent on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Deleted on")]
        public DateTime DeletedOn { get; set; }
    }
}
