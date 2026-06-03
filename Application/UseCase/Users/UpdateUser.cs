using System;
using MediatR;

namespace Application.UseCase.Users;

public sealed record UpdateUser(
    Guid Id,
    Guid RoleId,
    string Email,
    string Names,
    string LastNames,
    bool Active
) : IRequest<Unit>;
