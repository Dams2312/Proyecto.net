using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.VehicleMake;
using MediatR;

namespace Application.UseCase.VehicleMake;

public sealed class UpdateVehicleMakeHandler : IRequestHandler<UpdateVehicleMake, Unit>
{
    private readonly IUnitOfWork _uow;
    public UpdateVehicleMakeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateVehicleMake request, CancellationToken ct)
    {
        var entity = await _uow.VehicleMakes.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"VehicleMake '{request.Id}' no encontrado.");
        entity.UpdateName(VehicleMakeName.Create(request.Name));
        await _uow.VehicleMakes.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return Unit.Value;
    }
}