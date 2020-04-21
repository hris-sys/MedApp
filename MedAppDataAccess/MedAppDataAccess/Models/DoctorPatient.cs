﻿namespace MedAppDataAccess.Models
{
    public class DoctorPatient
    {
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
