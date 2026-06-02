using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class UpdateSupplierHandler : IRequestHandler<UpdateSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSupplierHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateSupplier request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
