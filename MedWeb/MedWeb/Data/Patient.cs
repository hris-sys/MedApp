using System.Collections.Generic;

namespace MedWeb.Models
{
    public class Patient : ApplicationUser
    {
        public Patient()
        {
            this.Doctors = new HashSet<DoctorPatient>();

            this.Appointments = new HashSet<Appointment>();

            this.Prescriptions = new HashSet<PatientPrescription>();
        }

        public IEnumerable<DoctorPatient> Doctors { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<PatientPrescription> Prescriptions { get; set; }
    }
}
