using FluentValidation;

namespace Application.UseCases.Invoice;

public sealed class CreateInvoiceValidator
    : AbstractValidator<CreateInvoice>
{
    public CreateInvoiceValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.StatusId)
            .GreaterThan(0)
            .WithMessage("El id del estado de la factura debe ser mayor a 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.CostoRepuestos)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El costo de repuestos no puede ser negativo.");

        RuleFor(x => x.ManoDeObra)
            .GreaterThanOrEqualTo(0)
            .WithMessage("La mano de obra no puede ser negativa.");

        RuleFor(x => x.ImpuestoPct)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100)
            .WithMessage("El impuesto debe estar entre 0 y 100.");

        RuleFor(x => x.Descuento)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El descuento no puede ser negativo.");

        RuleFor(x => x.Total)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El total no puede ser negativo.");
    }
}