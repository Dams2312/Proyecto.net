using System;
using FluentValidation;

namespace Application.UseCase.CustomerAddress;

public sealed class UpdateCustomerAddressValidator
    : AbstractValidator<UpdateCustomerAddress>
{
    public UpdateCustomerAddressValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CustomerId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del cliente es obligatorio.");

        RuleFor(x => x.CityId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la ciudad es obligatorio.");

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("La dirección es obligatoria.")
            .MaximumLength(255)
            .WithMessage("La dirección no puede superar los 255 caracteres.");
    }
}
