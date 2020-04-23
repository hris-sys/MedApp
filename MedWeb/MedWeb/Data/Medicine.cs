namespace MedWeb.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medicine
    {
        public Medicine()
        {
            this.ActiveIngredients = new HashSet<MedicineActiveIngredient>();

            this.PrescriptionMedicines = new HashSet<PrescriptionMedicines>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(15)]
        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<MedicineActiveIngredient> ActiveIngredients { get; set; }

        public ICollection<PrescriptionMedicines> PrescriptionMedicines { get; set; }
    }
}