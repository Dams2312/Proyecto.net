using Domain.Entities.CustomerEmails;
using Domain.ValueObject.CustomerEmail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerEmails;

public sealed class CustomerEmailConfiguration : IEntityTypeConfiguration<CustomerEmail>
{
    public void Configure(EntityTypeBuilder<CustomerEmail> builder)
    {
        builder.ToTable("CustomerEmail");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasConversion(
                x => x.Value,
                x => EmailCustomerId.Create(x))
            .HasColumnName("customer_id")
            .IsRequired();

        builder.Property(x => x.Address)
            .HasConversion(
                x => x.Value,
                x => CustomerEmailAddress.Create(x))
            .HasColumnName("address")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Primary)
            .HasConversion(
                x => x.Value,
                x => CustomerEmailPrimary.Create(x))
            .HasColumnName("primary")
            .IsRequired();

        builder.HasIndex(x => x.Address)
            .IsUnique();
    }
}