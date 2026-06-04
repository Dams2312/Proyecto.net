using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class GetVehicleMakeByIdHandler : IRequestHandler<GetVehicleMakeById, VehicleMakeEntity>
{
    private readonly IUnitOfWork _uow;
    public GetVehicleMakeByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<VehicleMakeEntity> Handle(GetVehicleMakeById request, CancellationToken ct)
        => await _uow.VehicleMakes.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"VehicleMake '{request.Id}' no encontrado.");
}