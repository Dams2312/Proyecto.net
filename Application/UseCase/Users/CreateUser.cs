using System;
using MediatR;

namespace Application.UseCase.Users;

public sealed record CreateUser(
    Guid RoleId,
    string Email,
    string Password,
    string Names,
    string LastNames
) : IRequest<Guid>;
