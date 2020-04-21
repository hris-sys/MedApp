using MedAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedAppDataAccess.ModelsConfiguring
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
