namespace MedApp.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> entity)
        {
            entity.HasKey(key => new { key.DoctorId, key.PatientId });
        }
    }
}
