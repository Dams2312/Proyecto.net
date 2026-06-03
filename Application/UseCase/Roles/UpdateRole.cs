using System;
using MediatR;

namespace Application.UseCase.Roles;

public sealed record UpdateRole(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;
