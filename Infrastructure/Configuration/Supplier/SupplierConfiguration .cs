using Domain.ValueObject.Supplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Supplier;

public sealed class SupplierConfiguration : IEntityTypeConfiguration<Domain.Entities.Supplier.Supplier>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Supplier.Supplier> builder)
    {
        builder.ToTable("proveedor");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => SupplierName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Nit)
            .HasConversion(
                x => x.Value,
                x => SupplierNit.Create(x))
            .HasColumnName("nit")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasConversion(
                x => x.Value,
                x => SupplierPhone.Create(x))
            .HasColumnName("telefono")
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasConversion(
                x => x.Value,
                x => SupplierEmail.Create(x))
            .HasColumnName("correo")
            .HasMaxLength(150);

        builder.Property(x => x.CityId)
            .HasColumnName("ciudad_id")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => SupplierActive.Create(x))
            .HasColumnName("activo")
            .IsRequired();

        builder.HasIndex(x => x.Nit)
            .IsUnique()
            .HasDatabaseName("uq_proveedor_nit");

        builder.HasOne<Domain.Entities.Citys.City>()
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .HasConstraintName("fk_proveedor_ciudad")
            .OnDelete(DeleteBehavior.Restrict);
    }
}