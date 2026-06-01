using System;
using FluentValidation;

namespace Application.UseCases.OrderMechanic;

public sealed class CreateOrderMechanicValidator
    : AbstractValidator<CreateOrderMechanic>
{
    public CreateOrderMechanicValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.MechanicId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del mecánico debe ser mayor a 0.");

        RuleFor(x => x.FechaAsignacion)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha de asignación es obligatoria.");
    }
}