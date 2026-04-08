using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;
using SoftBridge.Domain.Models.ServiceAggregates;
using System;
using System.Collections.Generic;
using System.Text;
using IServiceProvider =  SoftBridge.Domain.Models.AccountAggregates.SProvider;

namespace SoftBridge.Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasQueryFilter(s => !s.IsDeleted);

            builder.HasOne(x => x.Provider)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
