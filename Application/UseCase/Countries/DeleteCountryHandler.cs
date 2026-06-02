using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class DeleteCountryHandler
    : IRequestHandler<DeleteCountry, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCountryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCountry request,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(request.Id, ct);

        if (country is null)
            throw new KeyNotFoundException("PaÃ­s no encontrado.");

        await _uow.Countries.RemoveAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

