using FluentValidation;
namespace Application.UseCase.ServiceType;
public sealed class CreateServiceTypeValidator : AbstractValidator<CreateServiceType>
{
    public CreateServiceTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        RuleFor(x => x.EstimatedDays).GreaterThanOrEqualTo(0);
    }
}
