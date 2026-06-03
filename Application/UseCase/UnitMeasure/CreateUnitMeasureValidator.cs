using FluentValidation;
namespace Application.UseCase.UnitMeasure;
public sealed class CreateUnitMeasureValidator : AbstractValidator<CreateUnitMeasure>
{
    public CreateUnitMeasureValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Abbreviation).NotEmpty().MaximumLength(10);
    }
}
