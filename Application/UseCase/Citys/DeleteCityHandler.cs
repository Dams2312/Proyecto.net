using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed class DeleteCityHandler
    : IRequestHandler<DeleteCity, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCityHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCity request,
        CancellationToken ct)
    {
        var city = await _uow.Cities.GetByIdAsync(request.Id, ct);

        if (city is null)
            throw new KeyNotFoundException("Ciudad no encontrada.");

        await _uow.Cities.RemoveAsync(city, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

