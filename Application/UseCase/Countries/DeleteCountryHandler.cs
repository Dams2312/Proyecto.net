using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Countries;

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
            throw new KeyNotFoundException("País no encontrado.");

        await _uow.Countries.RemoveAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
