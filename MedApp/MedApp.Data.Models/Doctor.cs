namespace MedApp.Data.Models
{
    using System.Collections.Generic;

    public class Doctor : ApplicationUser
    {
        public Doctor()
        {
            this.Patients = new HashSet<DoctorPatient>();

            this.Appointments = new HashSet<Appointment>();
        }

        public string Description { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public IEnumerable<DoctorPatient> Patients { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}