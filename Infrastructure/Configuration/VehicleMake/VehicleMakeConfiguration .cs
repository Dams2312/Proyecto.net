using Domain.ValueObject.VehicleMake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.VehicleMake;

public sealed class VehicleMakeConfiguration : IEntityTypeConfiguration<Domain.Entities.VehicleMake.VehicleMake>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.VehicleMake.VehicleMake> builder)
    {
        builder.ToTable("marca_vehiculo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => VehicleMakeName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(80)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_marca_vehiculo_nombre");
    }
}