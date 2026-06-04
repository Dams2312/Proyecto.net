using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUser, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteUserHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteUser request, CancellationToken ct)
    {
        var entity = await _uow.Users.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Usuario con id {request.Id} no encontrado.");

        await _uow.Users.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}