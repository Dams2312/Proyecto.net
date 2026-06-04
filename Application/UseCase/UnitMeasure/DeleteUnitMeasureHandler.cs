using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class DeleteUnitMeasureHandler : IRequestHandler<DeleteUnitMeasure, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteUnitMeasureHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteUnitMeasure request, CancellationToken ct)
    {
        var entity = await _uow.UnitMeasures.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Unidad de medida con id {request.Id} no encontrada.");

        await _uow.UnitMeasures.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}