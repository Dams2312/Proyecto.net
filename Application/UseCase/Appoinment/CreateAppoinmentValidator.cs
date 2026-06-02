using System;
using FluentValidation;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed class CreateAppoinmentValidator
    : AbstractValidator<CreateAppoinment>
{
    public CreateAppoinmentValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del vehÃ­culo debe ser mayor a 0.");

        RuleFor(x => x.ServiceTypeId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del tipo de servicio debe ser mayor a 0.");

        RuleFor(x => x.ReceptionistId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del recepcionista debe ser mayor a 0.");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("La fecha de la cita es obligatoria.");

        RuleFor(x => x.StartTime)
            .NotEmpty()
            .WithMessage("La hora de inicio es obligatoria.");

        RuleFor(x => x.EndTime)
            .NotEmpty()
            .WithMessage("La hora de fin es obligatoria.");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("El estado de la cita es obligatorio.")
            .Must(s => s is "pendiente" or "confirmada" or "cancelada" or "completada")
            .WithMessage("El estado de la cita no es vÃ¡lido.");

        RuleFor(x => x.Observations)
            .MaximumLength(2000)
            .WithMessage("Las observaciones no pueden superar los 2000 caracteres.");
    }
}

