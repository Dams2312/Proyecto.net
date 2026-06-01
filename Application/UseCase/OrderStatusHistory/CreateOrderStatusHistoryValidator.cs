using FluentValidation;

namespace Application.UseCases.OrderStatusHistory;

public sealed class CreateOrderStatusHistoryValidator
    : AbstractValidator<CreateOrderStatusHistory>
{
    public CreateOrderStatusHistoryValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.StatusId)
            .GreaterThan(0)
            .WithMessage("El id del estado debe ser mayor a 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.FechaCambio)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha de cambio es obligatoria.");
    }
}