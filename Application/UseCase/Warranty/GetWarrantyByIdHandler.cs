using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class GetWarrantyByIdHandler : IRequestHandler<GetWarrantyById, WarrantyEntity>
{
    private readonly IUnitOfWork _uow;

    public GetWarrantyByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<WarrantyEntity> Handle(
        GetWarrantyById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
