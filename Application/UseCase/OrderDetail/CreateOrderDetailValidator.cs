using System;
using FluentValidation;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed class CreateOrderDetailValidator
    : AbstractValidator<CreateOrderDetail>
{
    public CreateOrderDetailValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.SparePartId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del repuesto es obligatorio.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("La cantidad debe ser mayor a 0.");

        RuleFor(x => x.PriceSnapshot)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El precio no puede ser negativo.");
    }
}
