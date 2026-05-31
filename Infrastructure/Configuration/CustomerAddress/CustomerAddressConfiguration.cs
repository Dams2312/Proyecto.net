using Domain.ValueObject.CustomerAddress;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerAddress;

public sealed class CustomerAddressConfiguration : IEntityTypeConfiguration<Domain.Entities.CustomerAddresses.CustomerAddress>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.CustomerAddresses.CustomerAddress> builder)
    {
        builder.ToTable("cliente_direccion");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // FKs COMO GUID, NO NECESITAN HasConversion
        builder.Property(x => x.CustomerId)
            .HasColumnName("cliente_id")
            .IsRequired();

        builder.Property(x => x.CityId)
            .HasColumnName("ciudad_id")
            .IsRequired();

        builder.Property(x => x.Street)
            .HasConversion(
                x => x.Value,
                x => CustomerAddressStreet.Create(x))
            .HasColumnName("direccion")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Primary)
            .HasConversion(
                x => x.Value,
                x => CustomerAddressPrimary.Create(x))
            .HasColumnName("principal")
            .IsRequired();

        builder.HasOne<Domain.Entities.Customers.Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.Citys.City>()
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}