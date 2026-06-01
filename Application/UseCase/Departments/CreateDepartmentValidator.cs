using System;
using FluentValidation;

namespace Application.UseCases.Departments;

public sealed class CreateDepartmentValidator
    : AbstractValidator<CreateDepartment>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El código del departamento es obligatorio.")
            .Length(4)
            .WithMessage("El código del departamento debe tener exactamente 4 caracteres.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del departamento es obligatorio.")
            .MinimumLength(2)
            .WithMessage("El nombre del departamento debe tener al menos 2 caracteres.")
            .MaximumLength(100)
            .WithMessage("El nombre del departamento no puede superar los 100 caracteres.");

        RuleFor(x => x.CountryId)
            .NotEqual(Guid.Empty)
            .WithMessage("El ID del país debe ser un número positivo.");
    }
}