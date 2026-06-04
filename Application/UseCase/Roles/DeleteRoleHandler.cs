using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRole, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteRoleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteRole request, CancellationToken ct)
    {
        var entity = await _uow.Roles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Rol con id {request.Id} no encontrado.");

        await _uow.Roles.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}