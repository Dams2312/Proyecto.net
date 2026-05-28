using System;
using Domain.common;
using Domain.ValueObject.Audit;

namespace Domain.Entities.Audit;

public sealed class Audit : BaseEntity<Guid>
{
    public AuditEntidad Entidad { get; private set; }
    public AuditFecha Fecha { get; private set; }
    public AuditTipoAccion TipoAccion { get; private set; }
    public AuditDatosAnteriores DatosAnteriores { get; private set; }
    public AuditDatosNuevos DatosNuevos { get; private set; }
    public AuditIpOrigen IpOrigen { get; private set; }

    private Audit() { }

    public Audit(
        AuditEntidad entidad,
        AuditFecha fecha,
        AuditTipoAccion tipoAccion,
        AuditDatosAnteriores datosAnteriores,
        AuditDatosNuevos datosNuevos,
        AuditIpOrigen ipOrigen)
    {
        Entidad = entidad ?? throw new ArgumentNullException(nameof(entidad));
        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
        TipoAccion = tipoAccion ?? throw new ArgumentNullException(nameof(tipoAccion));
        DatosAnteriores = datosAnteriores ?? throw new ArgumentNullException(nameof(datosAnteriores));
        DatosNuevos = datosNuevos ?? throw new ArgumentNullException(nameof(datosNuevos));
        IpOrigen = ipOrigen ?? throw new ArgumentNullException(nameof(ipOrigen));
    }

    public void UpdateEntidad(AuditEntidad entidad)
    {
        Entidad = entidad ?? throw new ArgumentNullException(nameof(entidad));
    }

    public void UpdateFecha(AuditFecha fecha)
    {
        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
    }

    public void UpdateTipoAccion(AuditTipoAccion tipoAccion)
    {
        TipoAccion = tipoAccion ?? throw new ArgumentNullException(nameof(tipoAccion));
    }

    public void UpdateDatosAnteriores(AuditDatosAnteriores datosAnteriores)
    {
        DatosAnteriores = datosAnteriores ?? throw new ArgumentNullException(nameof(datosAnteriores));
    }

    public void UpdateDatosNuevos(AuditDatosNuevos datosNuevos)
    {
        DatosNuevos = datosNuevos ?? throw new ArgumentNullException(nameof(datosNuevos));
    }

    public void UpdateIpOrigen(AuditIpOrigen ipOrigen)
    {
        IpOrigen = ipOrigen ?? throw new ArgumentNullException(nameof(ipOrigen));
    }
}
