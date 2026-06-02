using FluentValidation;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class CreateCountryValidator
    : AbstractValidator<CreateCountry>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del paÃ­s es obligatorio.")
            .MinimumLength(2)
            .WithMessage("El nombre del paÃ­s debe tener al menos 2 caracteres.")
            .MaximumLength(100)
            .WithMessage("El nombre del paÃ­s no puede superar los 100 caracteres.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El cÃ³digo del paÃ­s es obligatorio.")
            .Length(3)
            .WithMessage("El cÃ³digo del paÃ­s debe tener exactamente 3 caracteres.");
    }
}

