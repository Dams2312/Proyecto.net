using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Departments;
using MediatR;

namespace Application.UseCases.Departments;

public sealed class GetDepartmentsPagedHandler
    : IRequestHandler<GetDepartmentsPaged, IReadOnlyList<Department>>
{
    private readonly IUnitOfWork _uow;

    public GetDepartmentsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Department>> Handle(
        GetDepartmentsPaged request,
        CancellationToken ct)
    {
        return await _uow.Departments.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
