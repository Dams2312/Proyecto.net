using System.Collections.Generic;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed record GetUsersPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<UserEntity>>;
