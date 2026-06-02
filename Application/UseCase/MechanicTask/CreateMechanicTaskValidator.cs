using System;
using FluentValidation;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed class CreateMechanicTaskValidator
    : AbstractValidator<CreateMechanicTask>
{
    public CreateMechanicTaskValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.MechanicId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del mecÃ¡nico debe ser mayor a 0.");

        RuleFor(x => x.ServiceTypeId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del tipo de servicio debe ser mayor a 0.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La descripciÃ³n es obligatoria.")
            .MaximumLength(500)
            .WithMessage("La descripciÃ³n no puede superar los 500 caracteres.");

        RuleFor(x => x.HourlyCost)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El costo por hora no puede ser negativo.");

        RuleFor(x => x.HoursWorked)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Las horas trabajadas no pueden ser negativas.");

        RuleFor(x => x.FechaInicio)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha de inicio es obligatoria.");

        RuleFor(x => x.FechaFin)
            .Must((model, fechaFin) => fechaFin == default || (model.FechaInicio != default && fechaFin >= model.FechaInicio))
            .WithMessage("La fecha de fin no puede ser anterior a la fecha de inicio.");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("El estado es obligatorio.");
    }
}
