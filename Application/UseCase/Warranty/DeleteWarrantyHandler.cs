using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class DeleteWarrantyHandler : IRequestHandler<DeleteWarranty, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteWarrantyHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteWarranty request, CancellationToken ct)
    {
        var entity = await _uow.Warranties.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Garantía con id {request.Id} no encontrada.");

        await _uow.Warranties.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}