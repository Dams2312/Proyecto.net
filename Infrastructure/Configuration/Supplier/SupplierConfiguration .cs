using Domain.Entities.Supplier;
using Domain.ValueObject.Supplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Suppliers;

public sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => SupplierName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Nit)
            .HasConversion(
                x => x.Value,
                x => SupplierNit.Create(x))
            .HasColumnName("nit")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasConversion(
                x => x.Value,
                x => SupplierEmail.Create(x))
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasConversion(
                x => x.Value,
                x => SupplierPhone.Create(x))
            .HasColumnName("phone")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CityId)
            .HasConversion(
                x => x.Value,
                x => SupplierCityId.Create(x))
            .HasColumnName("city_id")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => SupplierActive.Create(x))
            .HasColumnName("active")
            .IsRequired();

        builder.HasIndex(x => x.Nit)
            .IsUnique();
    }
}