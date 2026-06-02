using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed class UpdateCityHandler
    : IRequestHandler<UpdateCity, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCityHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCity request,
        CancellationToken ct)
    {
        var city = await _uow.Cities.GetByIdAsync(request.Id, ct);

        if (city is null)
            throw new KeyNotFoundException("Ciudad no encontrada.");

        city.UpdateName(request.Name);
        city.UpdateDepartment(request.CountryId);
        city.UpdateCode(request.Code);

        await _uow.Cities.UpdateAsync(city, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

