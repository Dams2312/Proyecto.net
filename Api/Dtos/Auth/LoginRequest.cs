using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Auth;

public sealed class LoginRequest
{
    public string Email { get; init; } = default!; 
    public string Password { get; init; } = default!;
}
