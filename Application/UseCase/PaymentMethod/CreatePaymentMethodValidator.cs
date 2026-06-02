using FluentValidation;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed class CreatePaymentMethodValidator
    : AbstractValidator<CreatePaymentMethod>
{
    public CreatePaymentMethodValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del mÃ©todo de pago es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre no puede superar los 50 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La descripciÃ³n del mÃ©todo de pago es obligatorio.")
            .MaximumLength(200)
            .WithMessage("La descripciÃ³n no puede superar los 200 caracteres.");
    }
}
