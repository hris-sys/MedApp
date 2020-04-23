using MedWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedWeb.Data.ModelsConfiguration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> entity)
        {
            entity.HasMany(p => p.Patients)
                  .WithOne(pr => pr.Prescription)
                  .HasForeignKey(p => p.PrescriptionId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
