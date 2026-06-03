using FluentValidation;
namespace Application.UseCase.SpareCategory;
public sealed class CreateSpareCategoryValidator : AbstractValidator<CreateSpareCategory>
{
    public CreateSpareCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
    }
}
