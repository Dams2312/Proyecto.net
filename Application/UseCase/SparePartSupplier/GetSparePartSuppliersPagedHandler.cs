using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class GetSparePartSuppliersPagedHandler : IRequestHandler<GetSparePartSuppliersPaged, IReadOnlyList<SparePartSupplierEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetSparePartSuppliersPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<SparePartSupplierEntity>> Handle(GetSparePartSuppliersPaged request, CancellationToken ct)
    {
        return await _uow.SparePartSuppliers.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}