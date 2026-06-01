using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Audit;
using Domain.ValueObject.Audit;
using MediatR;
using AuditEntity = Domain.Entities.Audit.Audit;

namespace Application.UseCases.Audit;

public sealed class CreateAuditHandler
    : IRequestHandler<CreateAudit, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateAuditHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateAudit request,
        CancellationToken ct)
    {
        var tipo = AuditTipoAccion.Create(request.TipoAccion);
        var entidad = AuditEntidad.Create(request.Entidad);
        var datosNuevos = AuditDatosNuevos.Create(request.DatosNuevos);
        var datosAnteriores = AuditDatosAnteriores.Create(request.DatosAnteriores);
        var ip = AuditIpOrigen.Create(request.IpOrigen);
        var fecha = AuditFecha.Create(DateTime.UtcNow);

        var audit = new AuditEntity(
            request.UserId,
            request.EntidadId,
            entidad,
            fecha,
            tipo,
            datosAnteriores,
            datosNuevos,
            ip);

        await _uow.Audits.AddAsync(audit, ct);
        await _uow.SaveChangesAsync(ct);

        return audit.Id;
    }
}
