using MediatR;

namespace Application.UseCases.Departments;

public sealed record CreateDepartment(
    string Code,
    string Name,
    Guid CountryId
) : IRequest<Guid>;
