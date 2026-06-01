using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Citys;
using Domain.ValueObject.City;
using MediatR;

namespace Application.UseCases.Citys;

public sealed class CreateCityHandler
    : IRequestHandler<CreateCity, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCityHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCity request,
        CancellationToken ct)
    {
        var name = request.Name;
        var countryId = request.DepartmentId;
        var code = request.Code;

        var city = new City(name, countryId, code);

        await _uow.Cities.AddAsync(city, ct);
        await _uow.SaveChangesAsync(ct);

        return city.Id;
    }
}
