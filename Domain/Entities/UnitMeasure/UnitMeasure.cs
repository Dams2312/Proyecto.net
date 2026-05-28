using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.UnitMeasure;

namespace Domain.Entities.UnitMeasure;

public sealed class UnitMeasure : BaseEntity<Guid>
{
    public UnitMeasureName Name { get; private set; }
    public UnitMeasureAbbreviation Abbreviation { get; private set; }

    private UnitMeasure() { }

    public UnitMeasure(UnitMeasureName name, UnitMeasureAbbreviation abbreviation)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Abbreviation = abbreviation ?? throw new ArgumentNullException(nameof(abbreviation));
    }

    public void UpdateName(UnitMeasureName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateAbbreviation(UnitMeasureAbbreviation abbreviation)
    {
        Abbreviation = abbreviation ?? throw new ArgumentNullException(nameof(abbreviation));
    }
}
