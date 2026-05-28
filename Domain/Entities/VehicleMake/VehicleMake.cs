using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.VehicleMake;

namespace Domain.Entities.VehicleMake;

public sealed class VehicleMake : BaseEntity<Guid>
{
    public VehicleMakeName Name { get; private set; }

    private VehicleMake() { }

    public VehicleMake(VehicleMakeName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateName(VehicleMakeName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
