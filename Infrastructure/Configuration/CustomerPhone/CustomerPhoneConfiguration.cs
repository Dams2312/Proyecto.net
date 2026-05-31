using Domain.ValueObject.CustomerPhone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerPhone;

public sealed class CustomerPhoneConfiguration : IEntityTypeConfiguration<Domain.Entities.CustomerPhones.CustomerPhone>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.CustomerPhones.CustomerPhone> builder)
    {
        builder.ToTable("cliente_telefono");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // FK directa como Guid → cliente_id
        builder.Property(x => x.CustomerId)
            .HasColumnName("cliente_id")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasConversion(
                x => x.Value,
                x => CustomerPhoneNumber.Create(x))
            .HasColumnName("telefono")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.PhoneType)
            .HasConversion(
                x => x.Value,
                x => CustomerPhoneType.Create(x))
            .HasColumnName("tipo")
            .HasMaxLength(20)
            .IsRequired();

        // FK → cliente (ON DELETE CASCADE según SQL)
        builder.HasOne<Domain.Entities.Customers.Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}