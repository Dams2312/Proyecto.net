using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Departments;
using Domain.ValueObject.Department;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed class UpdateDepartmentHandler
    : IRequestHandler<UpdateDepartment, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateDepartmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateDepartment request,
        CancellationToken ct)
    {
        var entity = await _uow.Departments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Department no encontrado.");

        entity.UpdateCode(DepartmentCode.Create(request.Code));
        entity.UpdateName(DepartmentName.Create(request.Name));
        entity.UpdateCountry(request.CountryId);

        await _uow.Departments.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

