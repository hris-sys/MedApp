using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Data.Models;

namespace ToDo.Data.ModelsConfiguration
{
    public class ApplicationUserMessageConfiguration : IEntityTypeConfiguration<ApplicationUserMessage>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMessage> entity)
        {
            entity.HasKey(key => new { key.ApplicationUserId, key.MessageId });

            entity.HasOne(am => am.ApplicationUser)
                .WithMany(au => au.ApplicationUserMessages)
                .HasForeignKey(am => am.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(am => am.Message)
                .WithMany(m => m.ApplicationUserMessages)
                .HasForeignKey(m => m.MessageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
