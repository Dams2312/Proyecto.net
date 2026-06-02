using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUser, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteUserHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteUser request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
