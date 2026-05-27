using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Role;

namespace Domain.Entities.Roles;

public sealed class Role : BaseEntity<Guid>
{
    public RoleName Name { get; private set; }
    public RoleDescription Description { get; private set; }
    private Role() { }
    public Role(RoleName name, RoleDescription description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }
    public void UpdateName(RoleName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateDescription(RoleDescription description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }
}
