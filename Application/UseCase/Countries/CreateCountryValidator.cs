using FluentValidation;

namespace Application.UseCases.Countries;

public sealed class CreateCountryValidator
    : AbstractValidator<CreateCountry>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del país es obligatorio.")
            .MinimumLength(2)
            .WithMessage("El nombre del país debe tener al menos 2 caracteres.")
            .MaximumLength(100)
            .WithMessage("El nombre del país no puede superar los 100 caracteres.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El código del país es obligatorio.")
            .Length(3)
            .WithMessage("El código del país debe tener exactamente 3 caracteres.");
    }
}
