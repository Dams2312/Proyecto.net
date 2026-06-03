using System;
using FluentValidation;
namespace Application.UseCase.Users;
public sealed class CreateUserValidator : AbstractValidator<CreateUser>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Names).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastNames).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(100);
        RuleFor(x => x.RoleId).NotEqual(Guid.Empty);
    }
}
