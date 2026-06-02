using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed class GetMileageHistoriesPagedHandler
    : IRequestHandler<GetMileageHistoriesPaged, IReadOnlyList<MileageHistoryEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetMileageHistoriesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<MileageHistoryEntity>> Handle(
        GetMileageHistoriesPaged request,
        CancellationToken ct)
    {
        return await _uow.MileageHistories.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

