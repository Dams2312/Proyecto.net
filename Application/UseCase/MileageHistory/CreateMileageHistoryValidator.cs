using System;
using FluentValidation;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed class CreateMileageHistoryValidator
    : AbstractValidator<CreateMileageHistory>
{
    public CreateMileageHistoryValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del vehÃ­culo debe ser mayor a 0.");

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
