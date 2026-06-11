using Domain.ValueObject.VehicleModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.VehicleModel;

public sealed class VehicleModelConfiguration : IEntityTypeConfiguration<Domain.Entities.Vehiclemodel.VehicleModel>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Vehiclemodel.VehicleModel> builder)
    {
        builder.ToTable("modelo_vehiculo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.BrandId)
            .HasConversion(x => x.Value, x => VehicleModelMake.Create(x))
            .HasColumnName("marca_id")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => VehicleModelName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.YearFrom)
            .HasConversion(
                x => x == null ? (short?)null : x.Value,
                x => x == null ? null : VehicleModelYearFrom.Create(x.Value))
            .HasColumnName("anio_desde");

        builder.Property(x => x.YearTo)
            .HasConversion(
                x => x == null ? (short?)null : x.Value,
                x => x == null ? null : VehicleModelYearTo.Create(x.Value))
            .HasColumnName("anio_hasta");

    }
}
