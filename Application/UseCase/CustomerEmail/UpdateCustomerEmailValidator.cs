using System;
using FluentValidation;

namespace Application.UseCase.CustomerEmail;

public sealed class UpdateCustomerEmailValidator
    : AbstractValidator<UpdateCustomerEmail>
{
    public UpdateCustomerEmailValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CustomerId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del cliente es obligatorio.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("El correo es obligatorio.")
            .MaximumLength(150)
            .WithMessage("El correo no puede superar los 150 caracteres.");
    }
}
