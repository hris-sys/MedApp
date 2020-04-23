using MedWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedWeb.Data.ModelsConfiguration
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
