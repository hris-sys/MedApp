namespace MedWeb.Data.Models
{
    public class PatientPrescription
    {
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }
    }
}