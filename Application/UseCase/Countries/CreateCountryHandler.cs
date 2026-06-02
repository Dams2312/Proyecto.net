using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Countries;
using Domain.ValueObject.Country;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class CreateCountryHandler
    : IRequestHandler<CreateCountry, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCountryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCountry request,
        CancellationToken ct)
    {
        var name = CountryName.Create(request.Name);
        var code = CountryCode.Create(request.Code);

        var country = new Country(code, name);

        await _uow.Countries.AddAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return country.Id;
    }
}

