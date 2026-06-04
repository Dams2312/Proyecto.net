using Application.Abstractions;
using Domain.ValueObject.Warranty;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class UpdateWarrantyHandler : IRequestHandler<UpdateWarranty, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateWarrantyHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateWarranty request, CancellationToken ct)
    {
        var entity = await _uow.Warranties.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Garantía con id {request.Id} no encontrada.");

        entity.UpdateFechaInicio(WarrantyFechaInicio.Create(DateOnly.FromDateTime(request.StartDate)));
        entity.UpdateFechaVencimiento(WarrantyFechaVencimiento.Create(DateOnly.FromDateTime(request.EndDate)));
        entity.UpdateEstado(WarrantyEstado.Create(request.Status));
        entity.UpdateCondiciones(request.Conditions is not null
            ? WarrantyCondiciones.Create(request.Conditions)
            : null);

        await _uow.Warranties.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}