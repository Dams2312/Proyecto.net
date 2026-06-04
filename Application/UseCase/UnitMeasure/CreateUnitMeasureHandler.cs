using Application.Abstractions;
using Domain.ValueObject.UnitMeasure;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class CreateUnitMeasureHandler : IRequestHandler<CreateUnitMeasure, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateUnitMeasureHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateUnitMeasure request, CancellationToken ct)
    {
        var entity = new UnitMeasureEntity(
            UnitMeasureName.Create(request.Name),
            UnitMeasureAbbreviation.Create(request.Abbreviation)
        );

        await _uow.UnitMeasures.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}