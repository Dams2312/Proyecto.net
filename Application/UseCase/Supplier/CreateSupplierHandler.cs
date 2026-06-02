using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class CreateSupplierHandler : IRequestHandler<CreateSupplier, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSupplierHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateSupplier request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
