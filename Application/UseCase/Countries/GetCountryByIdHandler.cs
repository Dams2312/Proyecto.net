using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Countries;
using MediatR;

namespace Application.UseCases.Countries;

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
            throw new KeyNotFoundException("País no encontrado.");

        return country;
    }
}
