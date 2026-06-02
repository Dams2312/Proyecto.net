using System;
using FluentValidation;

namespace Application.UseCase.CustomerEmail;

public sealed class CreateCustomerEmailValidator
    : AbstractValidator<CreateCustomerEmail>
{
    public CreateCustomerEmailValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del cliente es obligatorio.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("El correo es obligatorio.")
            .MaximumLength(150)
            .WithMessage("El correo no puede superar los 150 caracteres.");

        // Primary is boolean
    }
}
