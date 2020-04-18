namespace MedAppDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Prescription
    {
        public Prescription()
        {
            this.PrescriptionMedicines = new HashSet<PrescriptionMedicines>();
        }
        public int Id { get; set; }

        public int PatientId { get; set; }

        public User Patient { get; set; }

        public int DoctorId { get; set; }

        public User Doctor { get; set; }

        public string Description { get; set; }

        public ICollection<PrescriptionMedicines> PrescriptionMedicines { get; set; }

        public DateTime DatePrescribed { get; set; }

        public DateTime DateExpired { get; set; }
    }
}
