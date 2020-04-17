namespace MedAppDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActiveIngredient
    {
        public ActiveIngredient()
        {
            this.MedicineActiveIngredients = new HashSet<MedicineActiveIngredient>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<MedicineActiveIngredient> MedicineActiveIngredients { get; set; }
    }
}
