using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Citys;

public class UpdateCitysRequest
{
    public Guid CountryId { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Code { get; init; } = default!;
}
