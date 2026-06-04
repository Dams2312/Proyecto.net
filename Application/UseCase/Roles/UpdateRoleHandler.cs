using Application.Abstractions;
using Domain.ValueObject.Role;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRole, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateRoleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateRole request, CancellationToken ct)
    {
        var entity = await _uow.Roles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Rol con id {request.Id} no encontrado.");

        entity.UpdateName(RoleName.Create(request.Name));
        entity.UpdateDescription(RoleDescription.Create(request.Description));

        await _uow.Roles.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}