using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Citys;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed class GetCityByIdHandler
    : IRequestHandler<GetCityById, City>
{
    private readonly IUnitOfWork _uow;

    public GetCityByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<City> Handle(
        GetCityById request,
        CancellationToken ct)
    {
        var city = await _uow.Cities.GetByIdAsync(request.Id, ct);

        if (city is null)
            throw new KeyNotFoundException("Ciudad no encontrada.");

        return city;
    }
}

