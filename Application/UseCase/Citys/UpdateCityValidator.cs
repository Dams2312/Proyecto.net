using FluentValidation;

namespace Application.UseCases.Citys;

public sealed class UpdateCityValidator
    : AbstractValidator<UpdateCity>
{
    public UpdateCityValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CountryId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(3);
    }
}
