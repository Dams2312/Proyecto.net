using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Citys;
using MediatR;

namespace Application.UseCases.Citys;

public sealed class GetCitysPagedHandler
    : IRequestHandler<GetCitysPaged, IReadOnlyList<City>>
{
    private readonly IUnitOfWork _uow;

    public GetCitysPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<City>> Handle(
        GetCitysPaged request,
        CancellationToken ct)
    {
        return await _uow.Cities.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
