using System;
using FluentValidation;
namespace Application.UseCase.VehicleModel;
public sealed class CreateVehicleModelValidator : AbstractValidator<CreateVehicleModel>
{
    public CreateVehicleModelValidator()
    {
        RuleFor(x => x.BrandId).NotEqual(Guid.Empty);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
