using FluentValidation;
namespace Application.UseCase.Warranty;
public sealed class CreateWarrantyValidator : AbstractValidator<CreateWarranty>
{
    public CreateWarrantyValidator()
    {
        RuleFor(x => x.Status).NotEmpty().MaximumLength(50);
        RuleFor(x => x.StartDate).NotEqual(default(System.DateTime));
        RuleFor(x => x.EndDate).NotEqual(default(System.DateTime));
    }
}
