using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class CreateSparePartHandler : IRequestHandler<CreateSparePart, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSparePartHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateSparePart request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
