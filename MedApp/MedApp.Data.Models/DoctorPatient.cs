namespace MedApp.Data.Models
{
    public class DoctorPatient
    {
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public string PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}