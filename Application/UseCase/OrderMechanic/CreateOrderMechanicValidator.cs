using System;
using FluentValidation;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

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
            .WithMessage("El id del mecÃ¡nico debe ser mayor a 0.");

        RuleFor(x => x.FechaAsignacion)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha de asignaciÃ³n es obligatoria.");
    }
}
