using Application.Abstractions;
using Domain.Entities.InvoiceStatus;
using Domain.ValueObject.InvoiceStatus;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCases.InvoiceStatus;

public sealed class CreateInvoiceStatusHandler
    : IRequestHandler<CreateInvoiceStatus, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateInvoiceStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateInvoiceStatus request,
        CancellationToken ct)
    {
        var name = InvoiceStatusName.Create(request.Name);

        var invoiceStatus = new InvoiceStatusEntity(name);

        await _uow.InvoiceStatuses.AddAsync(invoiceStatus, ct);

        await _uow.SaveChangesAsync(ct);

        return invoiceStatus.Id;
    }
}