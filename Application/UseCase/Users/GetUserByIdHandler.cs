using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserById, UserEntity>
{
    private readonly IUnitOfWork _uow;

    public GetUserByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<UserEntity> Handle(
        GetUserById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
