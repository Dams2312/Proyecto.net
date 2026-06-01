using MediatR;

namespace Application.UseCases.Departments;

public sealed record CreateDepartment(
    string Code,
    string Name,
    int CountryId
) : IRequest<Guid>;
