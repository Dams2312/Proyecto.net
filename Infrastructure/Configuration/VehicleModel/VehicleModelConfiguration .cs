using Domain.Entities.Vehiclemodel;
using Domain.ValueObject.VehicleModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.VehicleModels;

public sealed class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("VehicleModel");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.BrandId)
            .HasConversion(
                x => x.Value,
                x => VehicleModelMake.Create(x))
            .HasColumnName("brand_id")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => VehicleModelName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.YearFrom)
            .HasConversion(
                x => x!.Value,
                x => VehicleModelYearFrom.Create(x))
            .HasColumnName("year_from");

        builder.Property(x => x.YearTo)
            .HasConversion(
                x => x!.Value,
                x => VehicleModelYearTo.Create(x))
            .HasColumnName("year_to");
    }
}