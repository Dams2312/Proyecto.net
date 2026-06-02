using FluentValidation;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed class CreateInvoiceStatusValidator
    : AbstractValidator<CreateInvoiceStatus>
{
    public CreateInvoiceStatusValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del estado de la factura es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre del estado de la factura no puede superar los 50 caracteres.");
    }
}
