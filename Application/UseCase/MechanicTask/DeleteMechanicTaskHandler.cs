using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed class DeleteMechanicTaskHandler
    : IRequestHandler<DeleteMechanicTask, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteMechanicTaskHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteMechanicTask request,
        CancellationToken ct)
    {
        var entity = await _uow.MechanicTasks.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MechanicTask no encontrado.");

        await _uow.MechanicTasks.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
