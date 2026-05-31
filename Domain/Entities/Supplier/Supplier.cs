using System;
using Domain.common;
using Domain.ValueObject.Supplier;

namespace Domain.Entities.Supplier;

public sealed class Supplier : BaseEntity<Guid>
{
    public SupplierName Name { get; private set; }
    public SupplierNit Nit { get; private set; }
    public SupplierEmail Email { get; private set; }
    public SupplierPhone Phone { get; private set; }

    // FK como Guid
    public Guid CityId { get; private set; }

    public SupplierActive Active { get; private set; }

    private Supplier() { }

    public Supplier(
        SupplierName name,
        SupplierNit nit,
        SupplierEmail email,
        SupplierPhone phone,
        Guid cityId,
        SupplierActive active)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Nit = nit ?? throw new ArgumentNullException(nameof(nit));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));

        if (cityId == Guid.Empty)
            throw new ArgumentException("El id de la ciudad es obligatorio.", nameof(cityId));

        CityId = cityId;

        Active = active ?? throw new ArgumentNullException(nameof(active));
    }

    public void UpdateName(SupplierName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateNit(SupplierNit nit)
    {
        Nit = nit ?? throw new ArgumentNullException(nameof(nit));
    }

    public void UpdateEmail(SupplierEmail email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public void UpdatePhone(SupplierPhone phone)
    {
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
    }

    public void UpdateCityId(Guid cityId)
    {
        if (cityId == Guid.Empty)
            throw new ArgumentException("El id de la ciudad es obligatorio.", nameof(cityId));

        CityId = cityId;
    }

    public void UpdateActive(SupplierActive active)
    {
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }
}