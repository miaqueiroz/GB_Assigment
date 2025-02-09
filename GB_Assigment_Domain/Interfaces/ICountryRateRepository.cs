
using GB_Assigment_Domain.Models;

namespace GB_Assigment_Domain.Interfaces
{
    public interface ICountryRateRepository
    {
        List<CountryRate> GetCountryValidRates(string country);
    }
}
