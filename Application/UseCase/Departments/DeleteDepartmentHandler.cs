using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed class DeleteDepartmentHandler
    : IRequestHandler<DeleteDepartment, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteDepartmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteDepartment request,
        CancellationToken ct)
    {
        var entity = await _uow.Departments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Department no encontrado.");

        await _uow.Departments.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

