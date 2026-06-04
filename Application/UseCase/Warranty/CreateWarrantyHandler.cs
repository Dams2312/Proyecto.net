using Application.Abstractions;
using Domain.ValueObject.Warranty;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class CreateWarrantyHandler : IRequestHandler<CreateWarranty, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateWarrantyHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateWarranty request, CancellationToken ct)
    {
        var entity = new WarrantyEntity(
            request.OrderId,
            request.ServiceTypeId,
            request.MechanicId,
            WarrantyFechaInicio.Create(DateOnly.FromDateTime(request.StartDate)),
            WarrantyFechaVencimiento.Create(DateOnly.FromDateTime(request.EndDate)),
            WarrantyEstado.Create(request.Status),
            request.Conditions is not null ? WarrantyCondiciones.Create(request.Conditions) : null
        );

        await _uow.Warranties.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}