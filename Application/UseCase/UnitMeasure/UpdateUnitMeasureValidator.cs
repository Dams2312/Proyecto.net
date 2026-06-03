using FluentValidation;
namespace Application.UseCase.UnitMeasure;
public sealed class UpdateUnitMeasureValidator : AbstractValidator<UpdateUnitMeasure>
{
    public UpdateUnitMeasureValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Abbreviation).NotEmpty().MaximumLength(10);
    }
}
