using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class GetRolesPagedHandler : IRequestHandler<GetRolesPaged, IReadOnlyList<RoleEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetRolesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<RoleEntity>> Handle(
        GetRolesPaged request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
