using Domain.Entities.ServiceType;
using Domain.ValueObject.ServiceType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.ServiceTypes;

public sealed class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.ToTable("ServiceType");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeDescription.Create(x))
            .HasColumnName("description")
            .HasMaxLength(300);

        builder.Property(x => x.EstimatedDays)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeEstimatedDays.Create(x))
            .HasColumnName("estimated_days")
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}