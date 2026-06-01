using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Departament;

public sealed class DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public Guid CountryId { get; init; } = default!;
    public string Code { get; init; } = default!;
}
