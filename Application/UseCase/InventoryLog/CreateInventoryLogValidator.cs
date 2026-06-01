using FluentValidation;

namespace Application.UseCases.InventoryLog;

public sealed class CreateInventoryLogValidator
    : AbstractValidator<CreateInventoryLog>
{
    public CreateInventoryLogValidator()
    {
        RuleFor(x => x.SparePartId)
            .GreaterThan(0)
            .WithMessage("El id del repuesto debe ser mayor a 0.");

        RuleFor(x => x.Quantity)
            .NotEqual(0)
            .WithMessage("La cantidad no puede ser cero.");

        RuleFor(x => x.StockResultante)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El stock resultante no puede ser negativo.");

        RuleFor(x => x.TypeMovement)
            .NotEmpty()
            .WithMessage("El tipo de movimiento es obligatorio.")
            .Must(m => m is "entrada" or "salida" or "ajuste")
            .WithMessage("El tipo de movimiento no es válido. Debe ser 'entrada', 'salida' o 'ajuste'.");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.Fecha)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha del movimiento es obligatoria.");

        RuleFor(x => x.OrderId)
            .Must(v => !v.HasValue || v.Value > 0)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.PurchaseId)
            .Must(v => !v.HasValue || v.Value > 0)
            .WithMessage("El id de la compra debe ser mayor a 0.");

        RuleFor(x => x.Motivo)
            .MaximumLength(2000)
            .WithMessage("El motivo no puede superar los 2000 caracteres.");
    }
}