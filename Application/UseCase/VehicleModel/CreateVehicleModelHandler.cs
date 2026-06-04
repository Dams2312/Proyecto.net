using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.VehicleModel;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class CreateVehicleModelHandler : IRequestHandler<CreateVehicleModel, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateVehicleModelHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateVehicleModel request, CancellationToken ct)
    {
        var brandId  = VehicleModelMake.Create(request.BrandId);
        var name     = VehicleModelName.Create(request.Name);
        var yearFrom = request.YearFrom.HasValue ? VehicleModelYearFrom.Create((short)request.YearFrom.Value) : null;
        var yearTo   = request.YearTo.HasValue   ? VehicleModelYearTo.Create((short)request.YearTo.Value)     : null;
        var entity = new VehicleModelEntity(brandId, name, yearFrom, yearTo);
        await _uow.VehicleModels.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}