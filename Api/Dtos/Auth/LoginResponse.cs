using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Users;

namespace Api.Dtos.Auth;

public sealed class LoginResponse
{
    public string Token { get; init; } = default!;

    public DateTime Expiration { get; init; }

    public UserDto User { get; init; } = default!;
}
