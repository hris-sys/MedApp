namespace MedApp.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PatientPrescriptionConfiguration : IEntityTypeConfiguration<PatientPrescription>
    {
        public void Configure(EntityTypeBuilder<PatientPrescription> entity)
        {
            entity.HasKey(key => new { key.PatientId, key.PrescriptionId });
        }
    }
}
