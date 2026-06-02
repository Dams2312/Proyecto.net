using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed class DeleteAuditHandler
    : IRequestHandler<DeleteAudit, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteAuditHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteAudit request,
        CancellationToken ct)
    {
        var audit = await _uow.Audits.GetByIdAsync(request.Id, ct);

        if (audit is null)
            throw new KeyNotFoundException("AuditorÃ­a no encontrada.");

        await _uow.Audits.RemoveAsync(audit, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

