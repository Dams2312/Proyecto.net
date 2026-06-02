using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRole, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateRoleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateRole request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
