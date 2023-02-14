using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManager.Infrastructure.Configurations;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.Property(c => c.Id);

        builder.Property(c => c.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Suburb)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Category)
           .HasMaxLength(30)
           .IsRequired();

        builder.Property(c => c.Price)
            .IsRequired();

        builder.Property(c => c.AcceptedPrice)
            .IsRequired(false);

        builder.Property(c => c.Status)
            .IsRequired();

        builder.Property(c => c.JobId)
            .IsRequired();

        builder.Property(c => c.CreateAt)
            .IsRequired();

        builder.HasOne(e => e.Contact)
            .WithOne(c => c.Lead)
            .HasForeignKey<Lead>(e => e.ContactId);
    }
}
