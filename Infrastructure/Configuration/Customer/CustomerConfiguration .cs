using Domain.ValueObject.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Customer;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customers.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Customers.Customer> builder)
    {
        builder.ToTable("cliente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Names)
            .HasConversion(
                x => x.Value,
                x => CustomerNames.Create(x))
            .HasColumnName("nombres")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Surnames)
            .HasConversion(
                x => x.Value,
                x => CustomersSurnames.Create(x))
            .HasColumnName("apellidos")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasConversion(
                x => x.Value,
                x => CustomersDocumentType.Create(x))
            .HasColumnName("tipo_documento")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasConversion(
                x => x.Value,
                x => CustomerDocumentNumber.Create(x))
            .HasColumnName("num_documento")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.RegistrationDate)
            .HasConversion(
                x => x.Value,
                x => CustomerRegistrationDate.Create(x))
            .HasColumnName("fecha_registro")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => CustomerActive.Create(x))
            .HasColumnName("activo")
            .IsRequired();

        builder.HasIndex(x => x.DocumentNumber)
            .IsUnique()
            .HasDatabaseName("uq_cliente_num_documento");
    }
}