using Domain.ValueObject.PaymentMethod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.PaymentMethod;

public sealed class PaymentMethodConfiguration : IEntityTypeConfiguration<Domain.Entities.PaymentMethod.PaymentMethod>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.PaymentMethod.PaymentMethod> builder)
    {
        builder.ToTable("metodo_pago");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => PaymentMethodName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        // descripcion es nullable en el SQL
        builder.Property(x => x.Description)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : PaymentMethodDescription.Create(x))
            .HasColumnName("descripcion")
            .HasColumnType("text");

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_metodo_pago_nombre");
    }
}