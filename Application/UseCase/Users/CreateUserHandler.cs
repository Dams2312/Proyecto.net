using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Users;
using MediatR;
using UserEntity = Domain.Entities.Users.User;

namespace Application.UseCase.Users;

public sealed class CreateUserHandler : IRequestHandler<CreateUser, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHashService _passwordHashService;

    public CreateUserHandler(IUnitOfWork uow, IPasswordHashService passwordHashService)
    {
        _uow = uow;
        _passwordHashService = passwordHashService;
    }

    public async Task<Guid> Handle(CreateUser request, CancellationToken ct)
    {
        var code       = UsersCode.Create(Guid.NewGuid().ToString("N")[..8].ToUpper());
        var names      = UsersNames.Create(request.Names);
        var surnames   = UsersSurnames.Create(request.LastNames);
        var mail       = UsersMail.Create(request.Email);
        var password   = UsersPassword.Create(_passwordHashService.HashPassword(request.Password));
        var active     = UsersActive.Create(true);
        var createDate = UsersCreateDate.Create(DateTime.UtcNow);
        var finishDate = UsersFinishDate.Create(DateTime.UtcNow.AddYears(100));
        var roleId     = UsersrolId.Create(request.RoleId);

        var entity = new UserEntity(code, names, surnames, mail, password, active, createDate, finishDate, roleId);
        await _uow.Users.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}
