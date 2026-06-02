using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class CreateSpareCategoryHandler : IRequestHandler<CreateSpareCategory, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSpareCategoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateSpareCategory request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
