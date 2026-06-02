using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class CreateUserHandler : IRequestHandler<CreateUser, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateUserHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateUser request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
