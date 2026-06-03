using System;
using Api.Dtos.InventoryLog;
using Application.UseCase.InventoryLog;
using Domain.Entities.InventoryLog;
using Mapster;

namespace Api.Mappings;

public sealed class InventoryLogMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InventoryLog, InventoryLogDto>()
            .Map(dest => dest.SparePartId, src => src.SparePartId)
            .Map(dest => dest.Quantity, src => src.Quantity.Value)
            .Map(dest => dest.StockResultant, src => src.StockResultante.Value)
            .Map(dest => dest.TypeMovement, src => src.TypeMovement.Value)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Date, src => src.Fecha.Value)
            .Map(dest => dest.OrderId, src => src.OrderId)
            .Map(dest => dest.PurchaseId, src => src.PurchaseId)
            .Map(dest => dest.Reason, src => src.Motivo.Value);

        config.NewConfig<CreateInventoryLogRequest, CreateInventoryLog>()
            .MapWith(src => new CreateInventoryLog(
                src.SparePartId,
                src.Quantity,
                0,              // StockResultante: no viene en el request, se calcula en el handler
                src.TypeMovement,
                src.UserId,
                src.Date,
                src.OrderId,
                src.PurchaseId,
                src.Reason
            ));

        config.NewConfig<UpdateInventoryLogRequest, UpdateInventoryLog>()
            .MapWith(src => new UpdateInventoryLog(
                Guid.Empty,
                src.SparePartId,
                src.Quantity,
                0,              // StockResultante: no viene en el request, se calcula en el handler
                src.TypeMovement,
                src.UserId,
                src.Date,
                src.OrderId,
                src.PurchaseId,
                src.Reason
            ));
    }
}