using System;
using FluentValidation;
namespace Application.UseCase.Supplier;
public sealed class UpdateSupplierValidator : AbstractValidator<UpdateSupplier>
{
    public UpdateSupplierValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Nit).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CityId).NotEqual(Guid.Empty);
    }
}
