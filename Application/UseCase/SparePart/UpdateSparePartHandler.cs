using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class UpdateSparePartHandler : IRequestHandler<UpdateSparePart, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSparePartHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateSparePart request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
