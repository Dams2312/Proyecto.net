using Domain.Entities.OrderNote;
using Domain.ValueObject.OrderNote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderNotes;

public sealed class OrderNoteConfiguration : IEntityTypeConfiguration<OrderNote>
{
    public void Configure(EntityTypeBuilder<OrderNote> builder)
    {
        builder.ToTable("OrderNote");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => OrderNoteOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                x => x.Value,
                x => OrderNoteUserId.Create(x))
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.FechaNota)
            .HasConversion(
                x => x.Value,
                x => OrderNoteFechaNota.Create(x))
            .HasColumnName("fecha_nota")
            .IsRequired();

        builder.Property(x => x.Content)
            .HasConversion(
                x => x.Value,
                x => OrderNoteContent.Create(x))
            .HasColumnName("content")
            .HasMaxLength(1000)
            .IsRequired();
    }
}