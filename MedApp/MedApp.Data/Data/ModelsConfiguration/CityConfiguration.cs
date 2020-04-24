namespace MedApp.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.HasMany(c => c.Users)
                .WithOne(u => u.City)
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
