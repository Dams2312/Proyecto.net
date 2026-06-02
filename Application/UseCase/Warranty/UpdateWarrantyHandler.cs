using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class UpdateWarrantyHandler : IRequestHandler<UpdateWarranty, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateWarrantyHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateWarranty request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
