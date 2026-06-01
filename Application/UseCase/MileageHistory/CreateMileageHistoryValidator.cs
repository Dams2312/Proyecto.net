using FluentValidation;

namespace Application.UseCases.MileageHistory;

public sealed class CreateMileageHistoryValidator
    : AbstractValidator<CreateMileageHistory>
{
    public CreateMileageHistoryValidator()
    {
        RuleFor(x => x.VehicleId)
            .GreaterThan(0)
            .WithMessage("El id del vehículo debe ser mayor a 0.");

        RuleFor(x => x.Kilometraje)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El kilometraje no puede ser negativo.");

        RuleFor(x => x.Date)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha es obligatoria.");

        RuleFor(x => x.Source)
            .NotEmpty()
            .WithMessage("La fuente es obligatoria.")
            .MaximumLength(100)
            .WithMessage("La fuente no puede superar los 100 caracteres.");
    }
}