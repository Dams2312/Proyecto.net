using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class CreateSparePartSupplierHandler : IRequestHandler<CreateSparePartSupplier, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSparePartSupplierHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateSparePartSupplier request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
