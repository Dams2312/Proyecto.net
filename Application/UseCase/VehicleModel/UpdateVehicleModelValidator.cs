using System;
using FluentValidation;
namespace Application.UseCase.VehicleModel;
public sealed class UpdateVehicleModelValidator : AbstractValidator<UpdateVehicleModel>
{
    public UpdateVehicleModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.BrandId).NotEqual(Guid.Empty);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
