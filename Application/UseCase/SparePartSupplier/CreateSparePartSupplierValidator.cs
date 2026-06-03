using System;
using FluentValidation;
namespace Application.UseCase.SparePartSupplier;
public sealed class CreateSparePartSupplierValidator : AbstractValidator<CreateSparePartSupplier>
{
    public CreateSparePartSupplierValidator()
    {
        RuleFor(x => x.SparePartId).NotEqual(Guid.Empty);
        RuleFor(x => x.SupplierId).NotEqual(Guid.Empty);
        RuleFor(x => x.PurchasePrice).GreaterThanOrEqualTo(0);
    }
}
