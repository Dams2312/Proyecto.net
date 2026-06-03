using FluentValidation;
namespace Application.UseCase.SpareCategory;
public sealed class UpdateSpareCategoryValidator : AbstractValidator<UpdateSpareCategory>
{
    public UpdateSpareCategoryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
    }
}
