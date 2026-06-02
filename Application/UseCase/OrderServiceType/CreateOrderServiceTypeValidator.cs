using System;
using FluentValidation;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed class CreateOrderServiceTypeValidator
    : AbstractValidator<CreateOrderServiceType>
{
    public CreateOrderServiceTypeValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.ServiceTypeId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del tipo de servicio debe ser mayor a 0.");
    }
}
