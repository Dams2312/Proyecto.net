using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MechanicTask;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed class GetMechanicTaskByIdHandler
    : IRequestHandler<GetMechanicTaskById, MechanicTask>
{
    private readonly IUnitOfWork _uow;

    public GetMechanicTaskByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<MechanicTask> Handle(
        GetMechanicTaskById request,
        CancellationToken ct)
    {
        var entity = await _uow.MechanicTasks.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MechanicTask no encontrado.");

        return entity;
    }
}
