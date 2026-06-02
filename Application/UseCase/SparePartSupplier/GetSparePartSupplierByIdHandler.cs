using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class GetSparePartSupplierByIdHandler : IRequestHandler<GetSparePartSupplierById, SparePartSupplierEntity>
{
    private readonly IUnitOfWork _uow;

    public GetSparePartSupplierByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<SparePartSupplierEntity> Handle(
        GetSparePartSupplierById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
