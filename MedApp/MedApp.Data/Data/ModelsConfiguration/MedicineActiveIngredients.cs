﻿namespace MedApp.Data.ModelsConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class MedicineActiveIngredientConfiguring : IEntityTypeConfiguration<MedicineActiveIngredient>
    {
        public void Configure(EntityTypeBuilder<MedicineActiveIngredient> entity)
        {
            entity.HasKey(key => new { key.ActiveIngredientId, key.MedicineId });

            entity
                .HasOne(mai => mai.Medicine)
                .WithMany(m => m.ActiveIngredients)
                .HasForeignKey(m => m.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(mai => mai.ActiveIngredient)
                .WithMany(ai => ai.Medicines)
                .HasForeignKey(ai => ai.ActiveIngredientId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}