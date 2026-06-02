using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed class GetMechanicTasksPagedHandler
    : IRequestHandler<GetMechanicTasksPaged, IReadOnlyList<MechanicTaskEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetMechanicTasksPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<MechanicTaskEntity>> Handle(
        GetMechanicTasksPaged request,
        CancellationToken ct)
    {
        return await _uow.MechanicTasks.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

