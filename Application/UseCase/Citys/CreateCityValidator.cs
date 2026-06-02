using System;
using FluentValidation;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed class CreateCityValidator
    : AbstractValidator<CreateCity>
{
    public CreateCityValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre de la ciudad es obligatorio.")
            .MaximumLength(100)
            .WithMessage("El nombre de la ciudad no puede superar los 100 caracteres.");

        RuleFor(x => x.DepartmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("El id del departamento es obligatorio.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("El cÃ³digo de la ciudad es obligatorio.")
            .MaximumLength(10)
            .WithMessage("El cÃ³digo de la ciudad no puede superar los 10 caracteres.");
    }
}

