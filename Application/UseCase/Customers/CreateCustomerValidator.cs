using FluentValidation;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed class CreateCustomerValidator
    : AbstractValidator<CreateCustomer>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Names)
            .NotEmpty()
            .WithMessage("Los nombres son obligatorios.")
            .MinimumLength(2)
            .WithMessage("Los nombres deben tener al menos 2 caracteres.")
            .MaximumLength(100)
            .WithMessage("Los nombres no pueden superar los 100 caracteres.");

        RuleFor(x => x.Surnames)
            .NotEmpty()
            .WithMessage("Los apellidos son obligatorios.")
            .MinimumLength(2)
            .WithMessage("Los apellidos deben tener al menos 2 caracteres.")
            .MaximumLength(100)
            .WithMessage("Los apellidos no pueden superar los 100 caracteres.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("El nÃºmero de documento es obligatorio.")
            .MaximumLength(30)
            .WithMessage("El nÃºmero de documento no puede superar los 30 caracteres.");

        RuleFor(x => x.DocumentType)
            .NotEmpty()
            .WithMessage("El tipo de documento es obligatorio.")
            .MaximumLength(20)
            .WithMessage("El tipo de documento no puede superar los 20 caracteres.");
    }
}

