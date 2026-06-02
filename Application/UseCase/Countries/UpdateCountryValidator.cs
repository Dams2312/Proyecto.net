using FluentValidation;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class UpdateCountryValidator
    : AbstractValidator<UpdateCountry>
{
    public UpdateCountryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(3);
    }
}

