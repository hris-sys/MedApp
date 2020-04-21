using MedAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedAppDataAccess.ModelsConfiguring
{
    class PatientPrescribtionConfiguration : IEntityTypeConfiguration<PatientPrescription>
    {
        public void Configure(EntityTypeBuilder<PatientPrescription> entity)
        {
            entity.HasKey(key => new { key.PatientId, key.PrescriptionId });
        }
    }
}
