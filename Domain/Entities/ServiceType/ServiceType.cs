using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.ServiceType;

namespace Domain.Entities.ServiceType;

public sealed class ServiceType : BaseEntity<Guid>
{
    public ServiceTypeName Name { get; private set; }
    public ServiceTypeDescription Description { get; private set; }
    public ServiceTypeEstimatedDays EstimatedDays { get; private set; }

    private ServiceType() { }

    public ServiceType(
        ServiceTypeName name,
        ServiceTypeDescription description,
        ServiceTypeEstimatedDays estimatedDays)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        EstimatedDays = estimatedDays ?? throw new ArgumentNullException(nameof(estimatedDays));
    }

    public void UpdateName(ServiceTypeName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateDescription(ServiceTypeDescription description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void UpdateEstimatedDays(ServiceTypeEstimatedDays estimatedDays)
    {
        EstimatedDays = estimatedDays ?? throw new ArgumentNullException(nameof(estimatedDays));
    }
}
