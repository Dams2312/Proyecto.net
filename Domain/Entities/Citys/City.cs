using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.City;

namespace Domain.Entities.Citys;

public sealed class City : BaseEntity<Guid>
{
    public CityName Name { get; private set; }
    public CityCountryId CountryId { get; private set; }
    public CityCode Code { get; private set; }
    private City() { }
    public City( CityName name, CityCountryId countryId, CityCode code) 
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CountryId = countryId ?? throw new ArgumentNullException(nameof(countryId));
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }
    public void UpdateName(CityName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateCountry(CityCountryId countryId)
    {
        CountryId = countryId ?? throw new ArgumentNullException(nameof(countryId));
    }
}
