using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class GetSparePartsPagedHandler : IRequestHandler<GetSparePartsPaged, IReadOnlyList<SparePartEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetSparePartsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<SparePartEntity>> Handle(
        GetSparePartsPaged request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
