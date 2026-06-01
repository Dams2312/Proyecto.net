using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MechanicTask;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed class GetMechanicTasksPagedHandler
    : IRequestHandler<GetMechanicTasksPaged, IReadOnlyList<MechanicTask>>
{
    private readonly IUnitOfWork _uow;

    public GetMechanicTasksPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<MechanicTask>> Handle(
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
