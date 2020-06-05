using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(150)]
        public string ImageUrl { get; set; }
    }
}
