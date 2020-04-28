using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Data.Models;

namespace ToDo.Data.ModelsConfiguration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entity)
        {
            entity.HasOne(s => s.Sender)
                .WithMany(r => r.SentMessages)
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Recipient)
                .WithMany(r => r.ReceivedMessages)
                .HasForeignKey(r => r.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
