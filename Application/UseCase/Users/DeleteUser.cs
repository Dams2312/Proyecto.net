using System;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed record DeleteUser(Guid Id) : IRequest<Unit>;
