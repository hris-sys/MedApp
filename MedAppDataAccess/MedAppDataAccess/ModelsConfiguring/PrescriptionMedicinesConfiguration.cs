namespace MedAppDataAccess.ModelsConfiguring
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

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
