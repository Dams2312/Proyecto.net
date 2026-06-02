using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class CreateWarrantyHandler : IRequestHandler<CreateWarranty, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateWarrantyHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateWarranty request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
