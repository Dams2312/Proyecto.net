using FluentValidation;
namespace Application.UseCase.VehicleMake;
public sealed class CreateVehicleMakeValidator : AbstractValidator<CreateVehicleMake>
{
    public CreateVehicleMakeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
