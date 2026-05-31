using Domain.ValueObject.InvoiceStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.InvoiceStatus;

public sealed class InvoiceStatusConfiguration : IEntityTypeConfiguration<Domain.Entities.InvoiceStatus.InvoiceStatus>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.InvoiceStatus.InvoiceStatus> builder)
    {
        builder.ToTable("estado_factura");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => InvoiceStatusName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_estado_factura_nombre");
    }
}