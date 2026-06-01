using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MileageHistory;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed class GetMileageHistoriesPagedHandler
    : IRequestHandler<GetMileageHistoriesPaged, IReadOnlyList<MileageHistory>>
{
    private readonly IUnitOfWork _uow;

    public GetMileageHistoriesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<MileageHistory>> Handle(
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
