using System;
using FluentValidation;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class CreatePurchaseDetailValidator
    : AbstractValidator<CreatePurchaseDetail>
{
    public CreatePurchaseDetailValidator()
    {
        RuleFor(x => x.PurchaseId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la compra es obligatorio.");

        RuleFor(x => x.SparePartId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del repuesto es obligatorio.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("La cantidad debe ser mayor a 0.");

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El precio unitario no puede ser negativo.");
    }
}
