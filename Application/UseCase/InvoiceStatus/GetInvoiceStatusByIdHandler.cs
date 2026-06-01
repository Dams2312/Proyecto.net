using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InvoiceStatus;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed class GetInvoiceStatusByIdHandler
    : IRequestHandler<GetInvoiceStatusById, InvoiceStatus>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceStatusByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<InvoiceStatus> Handle(
        GetInvoiceStatusById request,
        CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InvoiceStatus no encontrado.");

        return entity;
    }
}
