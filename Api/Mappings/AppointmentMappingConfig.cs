using System;
using Api.Dtos.Appointment;
using Application.UseCase.AppointmentEntity;
using Domain.Entities.Appointment;
using Mapster;

namespace Api.Mappings;

public sealed class AppointmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Appointment, AppointmentDto>()
            .Map(dest => dest.Date, src => src.Date.Value)
            .Map(dest => dest.StartTime, src => src.StartTime.Value)
            .Map(dest => dest.EndTime, src => src.EndTime.Value)
            .Map(dest => dest.Status, src => src.Status.Value)
            .Map(dest => dest.Observations, src => src.Observations.Value);

        config.NewConfig<CreateAppointmentRequest, CreateAppoinment>()
            .MapWith(src => new CreateAppoinment(
                src.VehicleId,
                src.ServiceTypeId,
                src.ReceptionistId,
                src.Date,
                src.StartTime,
                src.EndTime,
                src.Status,
                src.Observations
            ));

        config.NewConfig<UpdateAppointmentRequest, UpdateAppoinment>()
            .MapWith(src => new UpdateAppoinment(
                Guid.Empty,
                src.VehicleId,
                src.ServiceTypeId,
                src.ReceptionistId,
                src.Date,
                src.StartTime,
                src.EndTime,
                src.Status,
                src.Observations
            ));
    }
}
