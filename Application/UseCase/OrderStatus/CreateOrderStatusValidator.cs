using FluentValidation;

namespace Application.UseCases.OrderStatus;

public sealed class CreateOrderStatusValidator
    : AbstractValidator<CreateOrderStatus>
{
    public CreateOrderStatusValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del estado de la orden es obligatorio.")
            .MaximumLength(50)
            .WithMessage("El nombre no puede superar los 50 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La descripción del estado de la orden es obligatorio.")
            .MaximumLength(200)
            .WithMessage("La descripción no puede superar los 200 caracteres.");
    }
}