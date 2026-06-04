using Application.Abstractions;
using MediatR;
using RoleEntity = Domain.Entities.Roles.Role;

namespace Application.UseCase.Roles;

public sealed class GetRoleByIdHandler : IRequestHandler<GetRoleById, RoleEntity>
{
    private readonly IUnitOfWork _uow;

    public GetRoleByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<RoleEntity> Handle(GetRoleById request, CancellationToken ct)
    {
        return await _uow.Roles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Rol con id {request.Id} no encontrado.");
    }
}