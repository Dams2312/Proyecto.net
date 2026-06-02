using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed class GetMechanicTaskByIdHandler
    : IRequestHandler<GetMechanicTaskById, MechanicTaskEntity>
{
    private readonly IUnitOfWork _uow;

    public GetMechanicTaskByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<MechanicTaskEntity> Handle(
        GetMechanicTaskById request,
        CancellationToken ct)
    {
        var entity = await _uow.MechanicTasks.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MechanicTaskEntity no encontrado.");

        return entity;
    }
}

