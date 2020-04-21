using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAppDataAccess.Models
{
    public class Patient : User
    {
        public Patient()
        {
            this.Doctors = new HashSet<DoctorPatient>();

            this.Appointments = new HashSet<Appointment>();

            this.Prescriptions = new HashSet<PatientPrescription>();
        }

        [Column("PatientId")]
        public override int Id { get; set; }

        public IEnumerable<DoctorPatient> Doctors { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<PatientPrescription> Prescriptions { get; set; }

    }
}
