using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed class GetMileageHistoryByIdHandler
    : IRequestHandler<GetMileageHistoryById, MileageHistoryEntity>
{
    private readonly IUnitOfWork _uow;

    public GetMileageHistoryByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<MileageHistoryEntity> Handle(
        GetMileageHistoryById request,
        CancellationToken ct)
    {
        var entity = await _uow.MileageHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MileageHistoryEntity no encontrado.");

        return entity;
    }
}

