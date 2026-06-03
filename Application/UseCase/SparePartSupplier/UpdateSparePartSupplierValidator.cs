using System;
using FluentValidation;
namespace Application.UseCase.SparePartSupplier;
public sealed class UpdateSparePartSupplierValidator : AbstractValidator<UpdateSparePartSupplier>
{
    public UpdateSparePartSupplierValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.SparePartId).NotEqual(Guid.Empty);
        RuleFor(x => x.SupplierId).NotEqual(Guid.Empty);
        RuleFor(x => x.PurchasePrice).GreaterThanOrEqualTo(0);
    }
}
