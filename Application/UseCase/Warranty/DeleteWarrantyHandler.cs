using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class DeleteWarrantyHandler : IRequestHandler<DeleteWarranty, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteWarrantyHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteWarranty request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
