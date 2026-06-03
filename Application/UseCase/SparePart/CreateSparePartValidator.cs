using System;
using FluentValidation;
namespace Application.UseCase.SparePart;
public sealed class CreateSparePartValidator : AbstractValidator<CreateSparePart>
{
    public CreateSparePartValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        RuleFor(x => x.PrecioUnitario).GreaterThanOrEqualTo(0);
        RuleFor(x => x.StockActual).GreaterThanOrEqualTo(0);
        RuleFor(x => x.StockMinimo).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEqual(Guid.Empty);
        RuleFor(x => x.UnitId).NotEqual(Guid.Empty);
    }
}
