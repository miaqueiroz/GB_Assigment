
using GB_Assigment_Domain.Interfaces;
using GB_Assigment_Domain.Models;

namespace GB_Assigment_Infrastructure.Repositories
{
    public class CountryRateRepository : ICountryRateRepository
    {
        public CountryRateRepository(){}

        public List<CountryRate> GetCountryValidRates(string country) 
        { 
            List<CountryRate> countryRates = new List<CountryRate>();

            countryRates.Add(new CountryRate
            {
                Id = 1,
                Country = country,
                VATRate = 10,
                IsActive = true
            });

            countryRates.Add(new CountryRate
            {
                Id = 2,
                Country = country,
                VATRate = 13,
                IsActive = true
            });

            countryRates.Add(new CountryRate
            {
                Id = 3,
                Country = country,
                VATRate = 20,
                IsActive = true
            });

            return countryRates;
        }

        /* If I had a db implementation,
         * I would inject our Context 
         * and use this method instead.
        public async Task<IEnumerable<CountryRate>> GetCountryValidRatesAsync(string country)
        {
            return await _context.CountryRates
            .Where(r => r.Country.Equals(country) && IsValid)
            .ToListAsync();
        }
        */
    }
}
