using System;
using Api.Dtos.MechanicTask;
using Application.UseCase.MechanicTask;
using Domain.Entities.MechanicTask;
using Mapster;

namespace Api.Mappings;

public sealed class MechanicTaskMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MechanicTask, MechanicTaskDto>()
            .Map(dest => dest.OrderId, src => src.OrderId.Value)
            .Map(dest => dest.MechanicId, src => src.MechanicId.Value)
            .Map(dest => dest.ServiceTypeId, src => src.ServiceTypeId.Value)
            .Map(dest => dest.Description, src => src.Description.Value)
            .Map(dest => dest.Status, src => src.Status.Value)
            .Map(dest => dest.FechaInicio, src => src.FechaInicio.Value)
            .Map(dest => dest.FechaFin, src => src.FechaFin.Value)
            .Map(dest => dest.HoursWorked, src => src.HoursWorked.Value)
            .Map(dest => dest.HourlyCost, src => src.HourlyCost.Value);

        config.NewConfig<CreateMechanicTaskRequest, CreateMechanicTask>()
            .MapWith(src => new CreateMechanicTask(
                src.OrderId,
                src.MechanicId,
                src.ServiceTypeId,
                src.Description,
                src.HourlyCost,
                src.HoursWorked,
                src.FechaInicio.GetValueOrDefault(),
                src.FechaFin.GetValueOrDefault(),
                src.Status
            ));

        config.NewConfig<UpdateMechanicTaskRequest, UpdateMechanicTask>()
            .MapWith(src => new UpdateMechanicTask(
                Guid.Empty,
                src.OrderId,
                src.MechanicId,
                src.ServiceTypeId,
                src.Description,
                src.HourlyCost,
                src.HoursWorked,
                src.FechaInicio.GetValueOrDefault(),
                src.FechaFin.GetValueOrDefault(),
                src.Status
            ));
    }
}
