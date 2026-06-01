using FluentValidation;

namespace Application.UseCases.Citys;

public sealed class CreateCityValidator
    : AbstractValidator<CreateCity>
{
    public CreateCityValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre de la ciudad es obligatorio.")
            .MaximumLength(100)
            .WithMessage("El nombre de la ciudad no puede superar los 100 caracteres.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0)
            .WithMessage("El id del país debe ser un número positivo.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El código de la ciudad es obligatorio.")
            .MaximumLength(10)
            .WithMessage("El código de la ciudad no puede superar los 10 caracteres.");
    }
}
