using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class GetSpareCategorysPagedHandler : IRequestHandler<GetSpareCategorysPaged, IReadOnlyList<SpareCategoryEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetSpareCategorysPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<SpareCategoryEntity>> Handle(
        GetSpareCategorysPaged request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
