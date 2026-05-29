using Domain.Entities.CustomerAddresses;
using Domain.ValueObject.CustomerAddress;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerAddresses;

public sealed class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddress");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasConversion(
                x => x.Value,
                x => AddressCustomerId.Create(x))
            .HasColumnName("customer_id")
            .IsRequired();

        builder.Property(x => x.Street)
            .HasConversion(
                x => x.Value,
                x => CustomerAddressStreet.Create(x))
            .HasColumnName("street")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Primary)
            .HasConversion(
                x => x.Value,
                x => CustomerAddressPrimary.Create(x))
            .HasColumnName("primary")
            .IsRequired();
    }
}