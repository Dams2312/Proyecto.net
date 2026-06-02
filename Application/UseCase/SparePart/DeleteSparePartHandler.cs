using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class DeleteSparePartHandler : IRequestHandler<DeleteSparePart, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSparePartHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteSparePart request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
