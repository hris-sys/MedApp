namespace MedWeb.Models
{
    public class PrescriptionMedicines
    {
        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}