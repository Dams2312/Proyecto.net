using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed class GetAuditByIdHandler
    : IRequestHandler<GetAuditById, AuditEntity>
{
    private readonly IUnitOfWork _uow;

    public GetAuditByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<AuditEntity> Handle(
        GetAuditById request,
        CancellationToken ct)
    {
        var audit = await _uow.Audits.GetByIdAsync(request.Id, ct);

        if (audit is null)
            throw new KeyNotFoundException("AuditorÃ­a no encontrada.");

        return audit;
    }
}

