using System;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed record CreateRole(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
