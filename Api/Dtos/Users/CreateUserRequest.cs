using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Users;

public sealed class CreateUserRequest
{
    public Guid RoleId { get; init; }

    public string Email { get; init; } = default!;

    public string Password { get; init; } = default!;

    public string Names { get; init; } = default!;

    public string LastNames { get; init; } = default!;
}
