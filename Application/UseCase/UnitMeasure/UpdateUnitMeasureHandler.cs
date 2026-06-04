using Application.Abstractions;
using Domain.ValueObject.UnitMeasure;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class UpdateUnitMeasureHandler : IRequestHandler<UpdateUnitMeasure, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateUnitMeasureHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateUnitMeasure request, CancellationToken ct)
    {
        var entity = await _uow.UnitMeasures.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Unidad de medida con id {request.Id} no encontrada.");

        entity.UpdateName(UnitMeasureName.Create(request.Name));
        entity.UpdateAbbreviation(UnitMeasureAbbreviation.Create(request.Abbreviation));

        await _uow.UnitMeasures.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}