using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class CreateRoleHandler : IRequestHandler<CreateRole, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateRoleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateRole request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
