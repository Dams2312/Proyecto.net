using Domain.Entities.CustomerPhones;
using Domain.ValueObject.CustomerPhone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerPhones;

public sealed class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
{
    public void Configure(EntityTypeBuilder<CustomerPhone> builder)
    {
        builder.ToTable("CustomerPhone");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PhoneNumber)
            .HasConversion(
                x => x.Value,
                x => CustomerPhoneNumber.Create(x))
            .HasColumnName("phone_number")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.PhoneType)
            .HasConversion(
                x => x.Value,
                x => CustomerPhoneType.Create(x))
            .HasColumnName("phone_type")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .HasConversion(
                x => x.Value,
                x => PhoneCustomerId.Create(x))
            .HasColumnName("customer_id")
            .IsRequired();
    }
}