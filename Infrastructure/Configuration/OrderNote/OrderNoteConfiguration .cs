using Domain.ValueObject.OrderNote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderNote;

public sealed class OrderNoteConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderNote.OrderNote>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderNote.OrderNote> builder)
    {
        builder.ToTable("nota_orden");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => OrderNoteOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => OrderNoteUserId.Create(x))
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(x => x.Content)
            .HasConversion(x => x.Value, x => OrderNoteContent.Create(x))
            .HasColumnName("contenido")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.FechaNota)
            .HasConversion(x => x.Value, x => OrderNoteFechaNota.Create(x))
            .HasColumnName("fecha_nota")
            .IsRequired();

        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey("orden_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey("usuario_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}