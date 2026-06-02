using FluentValidation;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class UpdateVehicleModelValidator : AbstractValidator<UpdateVehicleModel>
{
    public UpdateVehicleModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(100)
            .WithMessage("El nombre no puede superar los 100 caracteres.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El cÃ³digo es obligatorio.")
            .MaximumLength(10)
            .WithMessage("El cÃ³digo no puede superar los 10 caracteres.");
    }
}
