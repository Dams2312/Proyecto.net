using System;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed record UpdateUser(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
