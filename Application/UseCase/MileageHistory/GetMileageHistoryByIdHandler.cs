using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MileageHistory;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed class GetMileageHistoryByIdHandler
    : IRequestHandler<GetMileageHistoryById, MileageHistory>
{
    private readonly IUnitOfWork _uow;

    public GetMileageHistoryByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<MileageHistory> Handle(
        GetMileageHistoryById request,
        CancellationToken ct)
    {
        var entity = await _uow.MileageHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MileageHistory no encontrado.");

        return entity;
    }
}
