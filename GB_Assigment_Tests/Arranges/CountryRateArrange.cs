
using GB_Assigment_Domain.Models;
using System.Diagnostics.Metrics;

namespace GB_Assigment_Tests.Arranges
{
    public static class CountryRateArrange
    {
        public static List<CountryRate> GetExpectedRates()
        {
            List<CountryRate> countryRates = new List<CountryRate>();

            countryRates.Add(new CountryRate
            {
                Id = 1,
                Country = "Austria",
                VATRate = 10,
                IsActive = true
            });

            countryRates.Add(new CountryRate
            {
                Id = 2,
                Country = "Austria",
                VATRate = 13,
                IsActive = true
            });

            countryRates.Add(new CountryRate
            {
                Id = 3,
                Country = "Austria",
                VATRate = 20,
                IsActive = true
            });

            return countryRates;
        }

        public static CountryRate GetExpectedRate()
        {
            return new CountryRate
            {
                Id = 1,
                Country = "Austria",
                VATRate = 10,
                IsActive = true
            };
        }
    }
}
