using MedAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedAppDataAccess.ModelsConfiguring
{
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> entity)
        {
            entity.HasKey(key => new { key.DoctorId, key.PatientId });
        }
    }
}
