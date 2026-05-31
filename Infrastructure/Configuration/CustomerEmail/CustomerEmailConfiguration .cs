using Domain.ValueObject.CustomerEmail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.CustomerEmail;

public sealed class CustomerEmailConfiguration : IEntityTypeConfiguration<Domain.Entities.CustomerEmails.CustomerEmail>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.CustomerEmails.CustomerEmail> builder)
    {
        builder.ToTable("cliente_correo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // FK directa como Guid → cliente_id
        builder.Property(x => x.CustomerId)
            .HasColumnName("cliente_id")
            .IsRequired();

        builder.Property(x => x.Address)
            .HasConversion(
                x => x.Value,
                x => CustomerEmailAddress.Create(x))
            .HasColumnName("correo")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Primary)
            .HasConversion(
                x => x.Value,
                x => CustomerEmailPrimary.Create(x))
            .HasColumnName("principal")
            .IsRequired();

        // FK → cliente (ON DELETE CASCADE según SQL)
        builder.HasOne<Domain.Entities.Customers.Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}