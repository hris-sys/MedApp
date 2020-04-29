using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.ViewModels.Messages
{
    public class MessageInputModel
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required]
        [MinLength(10), MaxLength(5000)]
        [Display(Name = "Content:")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Recipient:")]
        public string ReceiverUserId { get; set; }
    }
}