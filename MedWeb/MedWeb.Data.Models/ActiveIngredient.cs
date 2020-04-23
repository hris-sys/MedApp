namespace MedWeb.Data.Models
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
        public string Name { get; set; }

        public ICollection<MedicineActiveIngredient> Medicines { get; set; }
    }
}