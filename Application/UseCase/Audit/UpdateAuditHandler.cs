using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Audit;
using MediatR;

namespace Application.UseCases.Audit;

public sealed class UpdateAuditHandler
    : IRequestHandler<UpdateAudit, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateAuditHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateAudit request,
        CancellationToken ct)
    {
        var audit = await _uow.Audits.GetByIdAsync(request.Id, ct);

        if (audit is null)
            throw new KeyNotFoundException("Auditoría no encontrada.");

        audit.UpdateEntidad(AuditEntidad.Create(request.Entity));
        audit.UpdateFecha(AuditFecha.Create(request.Date));
        audit.UpdateTipoAccion(AuditTipoAccion.Create(request.ActionType));
        audit.UpdateDatosAnteriores(AuditDatosAnteriores.Create(request.PreviousData));
        audit.UpdateDatosNuevos(AuditDatosNuevos.Create(request.NewData));
        audit.UpdateIpOrigen(AuditIpOrigen.Create(request.IpOrigin));

        await _uow.Audits.UpdateAsync(audit, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
