using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Contries;

public sealed class CountryDto
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public string Code { get; init; } = default!;
}
