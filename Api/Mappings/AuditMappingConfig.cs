using System;
using Api.Dtos.Audit;
using Application.UseCase.Audit;
using Domain.Entities.Audit;
using Mapster;

namespace Api.Mappings;

public sealed class AuditMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Audit, AuditDto>()
            .Map(dest => dest.Entity, src => src.Entidad.Value)
            .Map(dest => dest.Date, src => src.Fecha.Value)
            .Map(dest => dest.ActionType, src => src.TipoAccion.Value)
            .Map(dest => dest.PreviousData, src => src.DatosAnteriores != null ? src.DatosAnteriores.Value : null)
            .Map(dest => dest.NewData, src => src.DatosNuevos != null ? src.DatosNuevos.Value : null)
            .Map(dest => dest.IpOrigin, src => src.IpOrigen != null ? src.IpOrigen.Value : null);

            config.NewConfig<CreateAuditRequest, CreateAudit>()
                .MapWith(src => new CreateAudit(
                    src.UserId,
                    src.EntidadId,
                    src.ActionType,
                    src.Entity,
                    src.NewData,
                    src.PreviousData,
                    src.IpOrigin
                ));

        config.NewConfig<UpdateAuditRequest, UpdateAudit>()
            .MapWith(src => new UpdateAudit(
                Guid.Empty,
                src.Entity,
                src.Date,
                src.ActionType,
                src.PreviousData,
                src.NewData,
                src.IpOrigin
            ));
    }
}
