using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class GetUsersPagedHandler : IRequestHandler<GetUsersPaged, IReadOnlyList<UserEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetUsersPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<UserEntity>> Handle(GetUsersPaged request, CancellationToken ct)
    {
        return await _uow.Users.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}