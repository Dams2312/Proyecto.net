using System.Collections.Generic;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed record GetRolesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<RoleEntity>>;
