using FluentValidation;
namespace Application.UseCase.ServiceType;
public sealed class UpdateServiceTypeValidator : AbstractValidator<UpdateServiceType>
{
    public UpdateServiceTypeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        RuleFor(x => x.EstimatedDays).GreaterThanOrEqualTo(0);
    }
}
