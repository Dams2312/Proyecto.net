using Api.Dtos.Payment;
using Application.UseCase.Payment;
using Domain.Entities.Payment;
using Mapster;

namespace Api.Mappings;

public sealed class PaymentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Payment -> PaymentDto
        config.NewConfig<Payment, PaymentDto>()
            .Map(dest => dest.PaymentDate,
                src => src.FechaPago.Value)
            .Map(dest => dest.Amount,
                src => src.Monto.Value)
            .Map(dest => dest.Reference,
                src => src.Referencia.Value)
            .Map(dest => dest.Status,
                src => src.Estado.Value);

        // CreatePaymentRequest -> CreatePayment
        config.NewConfig<CreatePaymentRequest, CreatePayment>()
            .MapWith(src => new CreatePayment(
                src.InvoiceId,
                src.PaymentMethodId,
                src.PaymentDate,
                src.Amount,
                src.Reference,
                src.Status
            ));

        // UpdatePaymentRequest -> UpdatePayment
        config.NewConfig<UpdatePaymentRequest, UpdatePayment>()
            .MapWith(src => new UpdatePayment(
                Guid.Empty,
                src.InvoiceId,
                src.PaymentMethodId,
                src.PaymentDate,
                src.Amount,
                src.Reference,
                src.Status
            ));
    }
}
