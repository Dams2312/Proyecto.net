using FluentValidation;

namespace Application.UseCases.Audit;

public sealed class CreateAuditValidator
    : AbstractValidator<CreateAudit>
{
    public CreateAuditValidator()
    {
        RuleFor(x => x.TipoAccion)
            .NotEmpty()
            .WithMessage("El tipo de acción es obligatorio.")
            .Must(t => new[] { "INSERT", "UPDATE", "DELETE", "LOGIN", "LOGOUT" }.Contains(t?.ToUpperInvariant()))
            .WithMessage("El tipo de acción debe ser INSERT, UPDATE, DELETE, LOGIN o LOGOUT.");

        RuleFor(x => x.Entidad)
            .NotEmpty()
            .WithMessage("La entidad auditada es obligatoria.")
            .MaximumLength(80)
            .WithMessage("El nombre de la entidad no puede superar los 80 caracteres.");

        RuleFor(x => x.DatosNuevos)
            .MaximumLength(4000)
            .WithMessage("Los datos nuevos no pueden superar los 4000 caracteres.");

        RuleFor(x => x.DatosAnteriores)
            .MaximumLength(4000)
            .WithMessage("Los datos anteriores no pueden superar los 4000 caracteres.");

        RuleFor(x => x.IpOrigen)
            .MaximumLength(45)
            .WithMessage("La IP de origen no puede superar los 45 caracteres.");
    }
}
