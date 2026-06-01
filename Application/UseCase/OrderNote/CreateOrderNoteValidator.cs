using System;
using FluentValidation;

namespace Application.UseCases.OrderNote;

public sealed class CreateOrderNoteValidator
    : AbstractValidator<CreateOrderNote>
{
    public CreateOrderNoteValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id de la orden debe ser mayor a 0.");

        RuleFor(x => x.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del usuario debe ser mayor a 0.");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("El contenido es obligatorio.")
            .MaximumLength(1000)
            .WithMessage("El contenido no puede superar los 1000 caracteres.");

        RuleFor(x => x.FechaNota)
            .NotEqual(default(DateTime))
            .WithMessage("La fecha de la nota es obligatoria.");
    }
}