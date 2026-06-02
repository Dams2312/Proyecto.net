using Api.Dtos.PaymentMethod;
using Application.UseCase.PaymentMethod;
using Domain.Entities.PaymentMethod;
using Mapster;

namespace Api.Mappings;

public sealed class PaymentMethodMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // PaymentMethod -> PaymentMethodDto
        config.NewConfig<PaymentMethod, PaymentMethodDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Description,
                src => src.Description.Value);

        // CreatePaymentMethodRequest -> CreatePaymentMethod
        config.NewConfig<CreatePaymentMethodRequest, CreatePaymentMethod>()
            .MapWith(src => new CreatePaymentMethod(
                src.Name,
                src.Description
            ));

        // UpdatePaymentMethodRequest -> UpdatePaymentMethod
        config.NewConfig<UpdatePaymentMethodRequest, UpdatePaymentMethod>()
            .MapWith(src => new UpdatePaymentMethod(
                Guid.Empty,
                src.Name,
                src.Description
            ));
    }
}
