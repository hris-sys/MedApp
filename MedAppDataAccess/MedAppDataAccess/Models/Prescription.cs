namespace MedAppDataAccess.Models
{
    using System;
    using System.Collections.Generic;

    public class Prescription
    {
        public Prescription()
        {
            this.PrescriptionMedicines = new HashSet<PrescriptionMedicines>();

            this.Patients = new HashSet<PatientPrescription>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<PrescriptionMedicines> PrescriptionMedicines { get; set; }

        public IEnumerable<PatientPrescription> Patients { get; set; }

        public DateTime DatePrescribed { get; set; }

        public DateTime DateExpired { get; set; }
    }
}
