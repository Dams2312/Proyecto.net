using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Departments;
using MediatR;

namespace Application.UseCases.Departments;

public sealed class GetDepartmentByIdHandler
    : IRequestHandler<GetDepartmentById, Department>
{
    private readonly IUnitOfWork _uow;

    public GetDepartmentByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Department> Handle(
        GetDepartmentById request,
        CancellationToken ct)
    {
        var entity = await _uow.Departments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Department no encontrado.");

        return entity;
    }
}
