using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class GetUnitMeasuresPagedHandler : IRequestHandler<GetUnitMeasuresPaged, IReadOnlyList<UnitMeasureEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetUnitMeasuresPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<UnitMeasureEntity>> Handle(GetUnitMeasuresPaged request, CancellationToken ct)
    {
        return await _uow.UnitMeasures.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}