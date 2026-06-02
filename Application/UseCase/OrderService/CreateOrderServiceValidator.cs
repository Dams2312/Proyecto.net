using System;
using FluentValidation;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class CreateOrderServiceValidator
    : AbstractValidator<CreateOrderService>
{
    public CreateOrderServiceValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del vehÃ­culo debe ser mayor a 0.");

        RuleFor(x => x.ReceptionistId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del recepcionista debe ser mayor a 0.");

        RuleFor(x => x.StatusId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del estado debe ser mayor a 0.");

        RuleFor(x => x.KilometrajeIngreso)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El kilometraje de ingreso no puede ser negativo.");

        RuleFor(x => x.FechaIngreso)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha de ingreso es obligatoria.");

        RuleFor(x => x.FechaEstimada)
            .Must((model, fecha) => !fecha.HasValue || fecha.Value >= model.FechaIngreso)
            .WithMessage("La fecha estimada no puede ser anterior a la fecha de ingreso.");

        RuleFor(x => x.FechaEntregaReal)
            .Must((model, fecha) => !fecha.HasValue || fecha.Value >= model.FechaIngreso)
            .WithMessage("La fecha de entrega real no puede ser anterior a la fecha de ingreso.");

        RuleFor(x => x.AppointmentId)
            .NotEqual(Guid.Empty)
            .When(x => x.AppointmentId.HasValue)
            .WithMessage("El id de la cita debe ser mayor a 0.");

        RuleFor(x => x.Observaciones)
            .MaximumLength(1000)
            .WithMessage("Las observaciones no pueden superar los 1000 caracteres.");
    }
}
