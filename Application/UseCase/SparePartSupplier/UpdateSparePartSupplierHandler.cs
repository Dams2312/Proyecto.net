using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class UpdateSparePartSupplierHandler : IRequestHandler<UpdateSparePartSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSparePartSupplierHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateSparePartSupplier request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
