using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManager.Infrastructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(c => c.Id);

        builder.Property(c => c.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
           .HasMaxLength(15)
           .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(50)
            .IsRequired();
    }
}
