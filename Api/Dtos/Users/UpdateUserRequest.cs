using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Users;

public sealed class UpdateUserRequest
{
    public Guid RoleId { get; init; }

    public string Email { get; init; } = default!;

    public string Names { get; init; } = default!;

    public string LastNames { get; init; } = default!;

    public bool Active { get; init; }
}
