using FluentValidation;
namespace Application.UseCase.Vehicle;
public sealed class CreateVehicleValidator : AbstractValidator<CreateVehicle>
{
    public CreateVehicleValidator()
    {
        RuleFor(x => x.Vin).NotEmpty().MaximumLength(17);
        RuleFor(x => x.Plate).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Year).GreaterThan(1900);
        RuleFor(x => x.Color).NotEmpty().MaximumLength(50);
    }
}
