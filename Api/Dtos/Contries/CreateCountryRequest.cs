using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Contries;

public sealed class CreateCountryRequest    
{
    public string Name { get; init; } = default!;

    public string Code { get; init; } = default!;
}
