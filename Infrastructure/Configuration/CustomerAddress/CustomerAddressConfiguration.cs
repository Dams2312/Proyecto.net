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

        // FK directa como Guid → cliente_id
        builder.Property(x => x.CustomerId)
            .HasColumnName("cliente_id")
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

        // ciudad_id no existe en la entidad → ignorar (el SQL sí la tiene pero la entidad no la expone)

        // FK → cliente (ON DELETE CASCADE según SQL)
        builder.HasOne<Domain.Entities.Customers.Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}