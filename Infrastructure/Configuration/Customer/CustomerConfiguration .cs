using Domain.Entities.Customers;
using Domain.ValueObject.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Customers;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Names)
            .HasConversion(
                x => x.Value,
                x => CustomerNames.Create(x))
            .HasColumnName("names")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Surnames)
            .HasConversion(
                x => x.Value,
                x => CustomersSurnames.Create(x))
            .HasColumnName("surnames")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasConversion(
                x => x.Value,
                x => CustomerDocumentNumber.Create(x))
            .HasColumnName("document_number")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasConversion(
                x => x.Value,
                x => CustomersDocumentType.Create(x))
            .HasColumnName("document_type")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => CustomerActive.Create(x))
            .HasColumnName("active")
            .IsRequired();

        builder.Property(x => x.RegistrationDate)
            .HasConversion(
                x => x.Value,
                x => CustomerRegistrationDate.Create(x))
            .HasColumnName("registration_date")
            .IsRequired();

        builder.HasIndex(x => x.DocumentNumber)
            .IsUnique();
    }
}