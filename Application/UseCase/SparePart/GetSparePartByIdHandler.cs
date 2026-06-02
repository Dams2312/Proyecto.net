using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class GetSparePartByIdHandler : IRequestHandler<GetSparePartById, SparePartEntity>
{
    private readonly IUnitOfWork _uow;

    public GetSparePartByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<SparePartEntity> Handle(
        GetSparePartById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
