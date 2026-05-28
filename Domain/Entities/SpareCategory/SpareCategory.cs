using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.SpareCategory;

namespace Domain.Entities.SpareCategory;

public sealed class SpareCategory : BaseEntity<Guid>
{
    public SpareCategoryName Name { get; private set; }
    public SpareCategoryDescription Description { get; private set; }

    private SpareCategory() { }

    public SpareCategory(SpareCategoryName name, SpareCategoryDescription description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void UpdateName(SpareCategoryName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateDescription(SpareCategoryDescription description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }
}
