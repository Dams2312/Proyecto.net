using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.VehicleModel;

namespace Domain.Entities.Vehiclemodel;

public sealed class VehicleModel : BaseEntity<Guid>
{

    public VehicleModelMake BrandId { get; private set; }
    public VehicleModelName Name { get; private set; }

    public VehicleModelYearFrom? YearFrom { get; private set; }
    public VehicleModelYearTo? YearTo { get; private set; }

    private VehicleModel() { }

    public VehicleModel(
        VehicleModelMake brandId,
        VehicleModelName name,
        VehicleModelYearFrom? yearFrom,
        VehicleModelYearTo? yearTo)
    {
        if (yearFrom is not null &&
            yearTo is not null &&
            yearTo.Value < yearFrom.Value)
        {
            throw new ArgumentException(
                "El año hasta no puede ser menor al año desde.");
        }

        BrandId = brandId ?? throw new ArgumentNullException(nameof(brandId));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        YearFrom = yearFrom ?? throw new ArgumentNullException(nameof(yearFrom));
        YearTo = yearTo ?? throw new ArgumentNullException(nameof(yearTo));
    }
    public void UpdateName(VehicleModelName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public void UpdateYearFrom(VehicleModelYearFrom? yearFrom)
    {
        if (yearFrom is not null &&
            YearTo is not null &&
            yearFrom.Value > YearTo.Value)
        {
            throw new ArgumentException(
                "El año desde no puede ser mayor al año hasta.");
        }

        YearFrom = yearFrom ?? throw new ArgumentNullException(nameof(yearFrom));
    }
    public void UpdateYearTo(VehicleModelYearTo? yearTo)
    {
        if (yearTo is not null &&
            YearFrom is not null &&
            yearTo.Value < YearFrom.Value)
        {
            throw new ArgumentException(
                "El año hasta no puede ser menor al año desde.");
        }

        YearTo = yearTo ?? throw new ArgumentNullException(nameof(yearTo));
    }

}
