using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class GetServiceTypesPagedHandler : IRequestHandler<GetServiceTypesPaged, IReadOnlyList<ServiceTypeEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetServiceTypesPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<ServiceTypeEntity>> Handle(GetServiceTypesPaged request, CancellationToken ct)
    {
        return await _uow.ServiceTypes.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}