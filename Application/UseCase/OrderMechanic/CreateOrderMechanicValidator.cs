using FluentValidation;

namespace Application.UseCases.OrderMechanic;

public sealed class CreateOrderMechanicValidator
    : AbstractValidator<CreateOrderMechanic>
{
    public CreateOrderMechanicValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.MechanicId)
            .GreaterThan(0)
            .WithMessage("El id del mecánico debe ser mayor a 0.");

        RuleFor(x => x.FechaAsignacion)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha de asignación es obligatoria.");
    }
}