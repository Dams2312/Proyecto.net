using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Roles;

public sealed class RoleDto
{
    public Guid Id { get; init; }
    public string Name {get; init;} = default!;
    public string Description {get; init;} = default!;
}
