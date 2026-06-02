using System;
using FluentValidation;

namespace Application.UseCase.CustomerPhone;

public sealed class UpdateCustomerPhoneValidator
    : AbstractValidator<UpdateCustomerPhone>
{
    public UpdateCustomerPhoneValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CustomerId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del cliente es obligatorio.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("El teléfono es obligatorio.")
            .MaximumLength(20)
            .WithMessage("El teléfono no puede superar los 20 caracteres.");

        RuleFor(x => x.PhoneType)
            .NotEmpty()
            .WithMessage("El tipo de teléfono es obligatorio.")
            .MaximumLength(20)
            .WithMessage("El tipo de teléfono no puede superar los 20 caracteres.");
    }
}
