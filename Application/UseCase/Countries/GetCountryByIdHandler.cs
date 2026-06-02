using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Countries;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class GetCountryByIdHandler
    : IRequestHandler<GetCountryById, Country>
{
    private readonly IUnitOfWork _uow;

    public GetCountryByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Country> Handle(
        GetCountryById request,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(request.Id, ct);

        if (country is null)
            throw new KeyNotFoundException("PaÃ­s no encontrado.");

        return country;
    }
}

