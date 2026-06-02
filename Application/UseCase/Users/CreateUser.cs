using System;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed record CreateUser(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
