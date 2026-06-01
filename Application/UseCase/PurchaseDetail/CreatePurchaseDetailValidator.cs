using FluentValidation;

namespace Application.UseCases.PurchaseDetail;

public sealed class CreatePurchaseDetailValidator
    : AbstractValidator<CreatePurchaseDetail>
{
    public CreatePurchaseDetailValidator()
    {
        RuleFor(x => x.PurchaseId)
            .GreaterThan(0)
            .WithMessage("El id de la compra debe ser mayor a 0.");

        RuleFor(x => x.SparePartId)
            .GreaterThan(0)
            .WithMessage("El id del repuesto debe ser mayor a 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("La cantidad debe ser mayor a 0.");

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El precio unitario no puede ser negativo.");
    }
}