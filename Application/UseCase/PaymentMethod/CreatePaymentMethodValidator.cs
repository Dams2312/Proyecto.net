using FluentValidation;

namespace Application.UseCases.PaymentMethod;

public sealed class CreatePaymentMethodValidator
    : AbstractValidator<CreatePaymentMethod>
{
    public CreatePaymentMethodValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del método de pago es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre no puede superar los 50 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La descripción del método de pago es obligatorio.")
            .MaximumLength(200)
            .WithMessage("La descripción no puede superar los 200 caracteres.");
    }
}