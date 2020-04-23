namespace MedAppDataAccess.Models
{
    using System;

    public class Appointment
    {
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsExpired { get; set; }
    }
}
