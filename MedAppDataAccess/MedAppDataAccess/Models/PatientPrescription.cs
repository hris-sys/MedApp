using System;
using System.Collections.Generic;
using System.Text;

namespace MedAppDataAccess.Models
{
    public class PatientPrescription 
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }
    }
}
