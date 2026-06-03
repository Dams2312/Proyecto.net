using FluentValidation;
namespace Application.UseCase.VehicleMake;
public sealed class UpdateVehicleMakeValidator : AbstractValidator<UpdateVehicleMake>
{
    public UpdateVehicleMakeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
