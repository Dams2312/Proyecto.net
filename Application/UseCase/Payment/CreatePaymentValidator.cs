using System;
using FluentValidation;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed class CreatePaymentValidator
    : AbstractValidator<CreatePayment>
{
    public CreatePaymentValidator()
    {
        RuleFor(x => x.InvoiceId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la factura debe ser mayor a 0.");

        RuleFor(x => x.PaymentMethodId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del mÃ©todo de pago debe ser mayor a 0.");

        RuleFor(x => x.FechaPago)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha de pago es obligatoria.");

        RuleFor(x => x.Monto)
            .GreaterThan(0)
            .WithMessage("El monto debe ser mayor a 0.");

        RuleFor(x => x.Referencia)
            .NotEmpty()
            .WithMessage("La referencia es obligatoria.")
            .MaximumLength(100)
            .WithMessage("La referencia no puede superar los 100 caracteres.");

        RuleFor(x => x.Estado)
            .NotEmpty()
            .WithMessage("El estado es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El estado no puede superar los 50 caracteres.");
    }
}
