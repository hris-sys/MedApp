using System;
using System.Collections.Generic;
using System.Text;
using MedAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedAppDataAccess.ModelsConfiguring
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.HasMany(d => d.Patients)
                  .WithOne(dp => dp.Doctor)
                  .HasForeignKey(dp => dp.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(d => d.Appointments)
                  .WithOne(a => a.Doctor)
                  .HasForeignKey(d => d.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
