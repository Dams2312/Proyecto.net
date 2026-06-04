using System;
using Api.Dtos.Invoice;
using Application.UseCase.Invoice;
using Mapster;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Api.Mappings;

public sealed class InvoiceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InvoiceEntity, InvoiceDto>()
    .Map(dest => dest.OrderId, (InvoiceEntity src) => src.OrderId)
    .Map(dest => dest.StatusId, (InvoiceEntity src) => src.StatusId)
    .Map(dest => dest.UserId, (InvoiceEntity src) => src.UserId)
    .Map(dest => dest.PartsCost, (InvoiceEntity src) => src.CostoRepuestos.Value)
    .Map(dest => dest.LaborCost, (InvoiceEntity src) => src.ManoDeObra.Value)
    .Map(dest => dest.TaxPct, (InvoiceEntity src) => src.ImpuestoPct.Value)
    .Map(dest => dest.Discount, (InvoiceEntity src) => src.Descuento.Value)
    .Map(dest => dest.Total, (InvoiceEntity src) => src.Total.Value)
    .Ignore(dest => dest.StatusName)
    .Ignore(dest => dest.UserName);

        config.NewConfig<CreateInvoiceRequest, CreateInvoice>()
            .MapWith(src => new CreateInvoice(
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.PartsCost,
                src.LaborCost,
                src.TaxPct,
                src.Discount,
                src.Total
            ));

        config.NewConfig<UpdateInvoiceRequest, UpdateInvoice>()
            .MapWith(src => new UpdateInvoice(
                Guid.Empty,
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.PartsCost,
                src.LaborCost,
                src.TaxPct,
                src.Discount,
                src.Total
            ));
    }
}