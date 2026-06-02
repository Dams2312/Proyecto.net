using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class DeleteSpareCategoryHandler : IRequestHandler<DeleteSpareCategory, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSpareCategoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteSpareCategory request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
