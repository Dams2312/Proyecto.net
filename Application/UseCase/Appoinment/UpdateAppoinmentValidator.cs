using FluentValidation;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed class UpdateAppoinmentValidator
    : AbstractValidator<UpdateAppoinment>
{
    public UpdateAppoinmentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.VehicleId)
            .NotEmpty();

        RuleFor(x => x.ServiceTypeId)
            .NotEmpty();

        RuleFor(x => x.ReceptionistId)
            .NotEmpty();

        RuleFor(x => x.Date)
            .NotEqual(default(DateOnly));

        RuleFor(x => x.StartTime)
            .NotEqual(default(TimeOnly));

        RuleFor(x => x.EndTime)
            .NotEqual(default(TimeOnly));

        RuleFor(x => x.Status)
            .NotEmpty();

        RuleFor(x => x.Observations)
            .MaximumLength(2000);
    }
}

