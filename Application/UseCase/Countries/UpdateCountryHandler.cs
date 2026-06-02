using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Country;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class UpdateCountryHandler
    : IRequestHandler<UpdateCountry, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCountryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCountry request,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(request.Id, ct);

        if (country is null)
            throw new KeyNotFoundException($"Country with id '{request.Id}' was not found.");

        country.UpdateName(CountryName.Create(request.Name));
        country.UpdateCode(CountryCode.Create(request.Code));

        await _uow.Countries.UpdateAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

