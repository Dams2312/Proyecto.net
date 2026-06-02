using System;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed record UpdateRole(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
