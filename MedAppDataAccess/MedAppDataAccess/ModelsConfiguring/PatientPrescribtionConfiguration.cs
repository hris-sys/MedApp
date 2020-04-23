namespace MedAppDataAccess.ModelsConfiguring
{
    using MedAppDataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientPrescribtionConfiguration : IEntityTypeConfiguration<PatientPrescription>
    {
        public void Configure(EntityTypeBuilder<PatientPrescription> entity)
        {
            entity.HasKey(key => new { key.PatientId, key.PrescriptionId });
        }
    }
}
