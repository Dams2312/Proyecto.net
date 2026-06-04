using Application.Abstractions;
using Domain.ValueObject.Users;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUser, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateUserHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateUser request, CancellationToken ct)
    {
        var entity = await _uow.Users.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Usuario con id {request.Id} no encontrado.");

        entity.UpdateNames(UsersNames.Create(request.Names));
        entity.UpdateSurnames(UsersSurnames.Create(request.LastNames));
        entity.UpdateMail(UsersMail.Create(request.Email));
        entity.UpdateActive(UsersActive.Create(request.Active));
        entity.UpdateRoleId(UsersrolId.Create(request.RoleId));

        await _uow.Users.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}