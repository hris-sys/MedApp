namespace MedAppDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Medicine
    {
        public Medicine()
        {
            this.MedicineActiveIngredients = new HashSet<MedicineActiveIngredient>();

            this.PrescriptionMedicines = new HashSet<PrescriptionMedicines>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(15)]
        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<MedicineActiveIngredient> MedicineActiveIngredients { get; set; }

        public ICollection<PrescriptionMedicines> PrescriptionMedicines { get; set; }
    }
}
