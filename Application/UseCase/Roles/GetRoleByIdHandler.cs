using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class GetRoleByIdHandler : IRequestHandler<GetRoleById, RoleEntity>
{
    private readonly IUnitOfWork _uow;

    public GetRoleByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<RoleEntity> Handle(
        GetRoleById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
