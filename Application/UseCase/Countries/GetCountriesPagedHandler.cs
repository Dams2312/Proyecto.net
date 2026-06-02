using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Countries;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed class GetCountriesPagedHandler
    : IRequestHandler<GetCountriesPaged, IReadOnlyList<Country>>
{
    private readonly IUnitOfWork _uow;

    public GetCountriesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Country>> Handle(
        GetCountriesPaged request,
        CancellationToken ct)
    {
        return await _uow.Countries.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

