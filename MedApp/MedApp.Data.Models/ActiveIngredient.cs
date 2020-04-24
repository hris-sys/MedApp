namespace MedApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActiveIngredient
    {
        public ActiveIngredient()
        {
            this.Medicines = new HashSet<MedicineActiveIngredient>();
        }

        public int Id { get; set; }

        [Required]
        [Range(5, 50)]
        public string Name { get; set; }

        public ICollection<MedicineActiveIngredient> Medicines { get; set; }
    }
}