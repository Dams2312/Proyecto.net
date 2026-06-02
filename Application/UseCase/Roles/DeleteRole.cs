using System;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed record DeleteRole(Guid Id) : IRequest<Unit>;
