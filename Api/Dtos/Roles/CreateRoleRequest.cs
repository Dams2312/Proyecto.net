using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Roles;

public class CreateRoleRequest
{
    public string Name {get; init;} = default!;
    public string Description {get; init;} = default!;
}
