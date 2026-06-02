using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRole, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteRoleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteRole request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
