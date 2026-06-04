using Application.Abstractions;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class GetSuppliersPagedHandler : IRequestHandler<GetSuppliersPaged, IReadOnlyList<SupplierEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetSuppliersPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<SupplierEntity>> Handle(GetSuppliersPaged request, CancellationToken ct)
    {
        return await _uow.Suppliers.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}