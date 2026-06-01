using FluentValidation;

namespace Application.UseCases.OrderDetail;

public sealed class CreateOrderDetailValidator
    : AbstractValidator<CreateOrderDetail>
{
    public CreateOrderDetailValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.SparePartId)
            .GreaterThan(0)
            .WithMessage("El id del repuesto debe ser mayor a 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("La cantidad debe ser mayor a 0.");

        RuleFor(x => x.PriceSnapshot)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El precio no puede ser negativo.");
    }
}