using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class UpdateSpareCategoryHandler : IRequestHandler<UpdateSpareCategory, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSpareCategoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateSpareCategory request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
