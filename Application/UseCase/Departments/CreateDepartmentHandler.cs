using Application.Abstractions;
using Domain.Entities.Departments;
using Domain.ValueObject.Department;
using MediatR;

namespace Application.UseCases.Departments;

public sealed class CreateDepartmentHandler
    : IRequestHandler<CreateDepartment, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateDepartmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateDepartment request,
        CancellationToken ct)
    {
        var code = DepartmentCode.Create(request.Code);

        var name = DepartmentName.Create(request.Name);

        var department = new Department(
            code,
            name,
            request.CountryId);

        await _uow.Departments.AddAsync(department, ct);

        await _uow.SaveChangesAsync(ct);

        return department.Id;
    }
}