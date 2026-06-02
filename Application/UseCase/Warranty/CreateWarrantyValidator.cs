using FluentValidation;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class CreateWarrantyValidator : AbstractValidator<CreateWarranty>
{
    public CreateWarrantyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.")
            .MaximumLength(100)
            .WithMessage("El nombre no puede superar los 100 caracteres.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El cÃ³digo es obligatorio.")
            .MaximumLength(10)
            .WithMessage("El cÃ³digo no puede superar los 10 caracteres.");
    }
}
