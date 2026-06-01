using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed class DeleteMileageHistoryHandler
    : IRequestHandler<DeleteMileageHistory, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteMileageHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteMileageHistory request,
        CancellationToken ct)
    {
        var entity = await _uow.MileageHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MileageHistory no encontrado.");

        await _uow.MileageHistories.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
