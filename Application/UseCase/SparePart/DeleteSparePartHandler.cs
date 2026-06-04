using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class DeleteSparePartHandler : IRequestHandler<DeleteSparePart, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSparePartHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteSparePart request, CancellationToken ct)
    {
        var entity = await _uow.SpareParts.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Repuesto con id {request.Id} no encontrado.");

        await _uow.SpareParts.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}