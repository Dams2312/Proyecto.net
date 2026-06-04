using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserById, UserEntity>
{
    private readonly IUnitOfWork _uow;

    public GetUserByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<UserEntity> Handle(GetUserById request, CancellationToken ct)
    {
        return await _uow.Users.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Usuario con id {request.Id} no encontrado.");
    }
}