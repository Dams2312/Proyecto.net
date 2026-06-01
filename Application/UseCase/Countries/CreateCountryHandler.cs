using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Country;
using Domain.ValueObject.Country;
using MediatR;

namespace Application.UseCases.Countries;

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

        var country = new Country(name, code);

        await _uow.Countries.AddAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return country.Id;
    }
}
