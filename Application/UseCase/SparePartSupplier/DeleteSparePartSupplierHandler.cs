using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class DeleteSparePartSupplierHandler : IRequestHandler<DeleteSparePartSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSparePartSupplierHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteSparePartSupplier request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
