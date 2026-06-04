using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCase.VehicleMake;

public sealed class DeleteVehicleMakeHandler : IRequestHandler<DeleteVehicleMake, Unit>
{
    private readonly IUnitOfWork _uow;
    public DeleteVehicleMakeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteVehicleMake request, CancellationToken ct)
    {
        var entity = await _uow.VehicleMakes.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"VehicleMake '{request.Id}' no encontrado.");
        await _uow.VehicleMakes.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return Unit.Value;
    }
}