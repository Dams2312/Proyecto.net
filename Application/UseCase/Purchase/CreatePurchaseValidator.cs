using System;
using FluentValidation;

namespace Application.UseCases.Purchase;

public sealed class CreatePurchaseValidator
    : AbstractValidator<CreatePurchase>
{
    public CreatePurchaseValidator()
    {
        RuleFor(x => x.Date)
            .NotEqual(default(DateOnly))
            .WithMessage("La fecha es obligatoria.");

        RuleFor(x => x.SupplierId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del proveedor debe ser mayor a 0.");

        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("El estado es obligatorio.");

        RuleFor(x => x.Observations)
            .MaximumLength(500)
            .WithMessage("Las observaciones no pueden superar los 500 caracteres.");

        RuleFor(x => x.Total)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El total no puede ser negativo.");
    }
}