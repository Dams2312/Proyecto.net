using FluentValidation;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed class UpdateAuditValidator
    : AbstractValidator<UpdateAudit>
{
    public UpdateAuditValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Entity)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Date)
            .NotEqual(default(DateTime));

        RuleFor(x => x.ActionType)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.PreviousData)
            .MaximumLength(2000);

        RuleFor(x => x.NewData)
            .MaximumLength(2000);

        RuleFor(x => x.IpOrigin)
            .MaximumLength(100);
    }
}

