using System;
using FluentValidation;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class CreateOrderStatusHistoryValidator
    : AbstractValidator<CreateOrderStatusHistory>
{
    public CreateOrderStatusHistoryValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.StatusId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del estado debe ser mayor a 0.");

        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.FechaCambio)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha de cambio es obligatoria.");
    }
}
