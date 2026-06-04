using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.VehicleMake;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class CreateVehicleMakeHandler : IRequestHandler<CreateVehicleMake, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateVehicleMakeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateVehicleMake request, CancellationToken ct)
    {
        var name   = VehicleMakeName.Create(request.Name);
        var entity = new VehicleMakeEntity(name);
        await _uow.VehicleMakes.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}