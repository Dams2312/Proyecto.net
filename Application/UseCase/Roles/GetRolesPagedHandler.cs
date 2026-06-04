using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class GetRolesPagedHandler : IRequestHandler<GetRolesPaged, IReadOnlyList<RoleEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetRolesPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<RoleEntity>> Handle(GetRolesPaged request, CancellationToken ct)
    {
        return await _uow.Roles.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}