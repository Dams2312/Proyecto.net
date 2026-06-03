using System;
using FluentValidation;
namespace Application.UseCase.Supplier;
public sealed class CreateSupplierValidator : AbstractValidator<CreateSupplier>
{
    public CreateSupplierValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Nit).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CityId).NotEqual(Guid.Empty);
    }
}
