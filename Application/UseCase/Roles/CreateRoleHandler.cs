using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Role;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class CreateRoleHandler : IRequestHandler<CreateRole, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateRoleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateRole request, CancellationToken ct)
    {
        var name = RoleName.Create(request.Name);
        var desc = RoleDescription.Create(request.Description);
        var entity = new RoleEntity(name, desc);
        await _uow.Roles.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}