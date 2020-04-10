using System;
using System.Collections.Generic;

namespace MedAppDataAccess.Models
{
    public class Prescription
    {
        public Prescription()
        {
            this.Medicines = new HashSet<Medicine>();
        }
        public int Id { get; set; }

        public int PatientId { get; set; }
        public User Patient { get; set; }

        public int DoctorId { get; set; }
        public User Doctor { get; set; }

        public string Description { get; set; }

        public ICollection<Medicine> Medicines { get; set; }

        public DateTime DatePrescribed { get; set; }
        public DateTime DateExpired { get; set; }
    }
}
