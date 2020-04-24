namespace MedApp.Data.Models
{
    using System;

    public class Appointment
    {
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsExpired { get; set; }
    }
}