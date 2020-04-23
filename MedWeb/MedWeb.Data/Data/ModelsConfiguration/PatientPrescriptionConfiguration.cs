using MedWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedWeb.Data.ModelsConfiguration
{
    public class PatientPrescriptionConfiguration : IEntityTypeConfiguration<PatientPrescription>
    {
        public void Configure(EntityTypeBuilder<PatientPrescription> entity)
        {
            entity.HasKey(key => new { key.PatientId, key.PrescriptionId });
        }
    }
}
