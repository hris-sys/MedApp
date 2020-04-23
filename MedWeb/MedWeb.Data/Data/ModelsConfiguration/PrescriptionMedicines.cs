using MedWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedWeb.Data.ModelsConfiguration
{
    public class PrescriptionMedicinesConfiguration : IEntityTypeConfiguration<PrescriptionMedicines>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicines> entity)
        {
            entity.HasKey(key => new { key.PrescriptionId, key.MedicineId });

            entity
                .HasOne(p => p.Prescription)
                .WithMany(pm => pm.PrescriptionMedicines)
                .HasForeignKey(pm => pm.PrescriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.Medicine)
                .WithMany(pm => pm.PrescriptionMedicines)
                .HasForeignKey(pm => pm.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
