using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Country;

namespace Domain.Entities.Countries;

public sealed class Country : BaseEntity<Guid>
{
    public CountryCode Code { get; private set; }
    public CountryName Name { get; private set; }
    private Country() { }
    public Country(CountryCode code, CountryName name)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public void UpdateCode(CountryCode code)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }

    public void UpdateName(CountryName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
