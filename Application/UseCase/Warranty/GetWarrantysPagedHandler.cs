using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class GetWarrantysPagedHandler : IRequestHandler<GetWarrantysPaged, IReadOnlyList<WarrantyEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetWarrantysPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<WarrantyEntity>> Handle(
        GetWarrantysPaged request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
