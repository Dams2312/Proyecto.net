using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUser, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateUserHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateUser request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
