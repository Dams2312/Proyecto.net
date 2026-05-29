using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Users;

public sealed class ChangePasswordRequest
{
    public string CurrentPassword { get; init; } = default!;
    public string NewPassword { get; init; } = default!;  
}
