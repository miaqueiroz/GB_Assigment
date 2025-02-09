using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Interfaces;
using GB_Assigment_Domain.Constants;
using GB_Assigment_Domain.Interfaces;
using GB_Assigment_Domain.Models;
using Serilog;


namespace GB_Assigment_Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ILogger _logger;
        private readonly ICountryRateRepository _countryRateRepository;

        public ValidationService(
            ILogger logger,
            ICountryRateRepository countryRateRepository
        ) 
        { 
            _logger = logger;
            _countryRateRepository = countryRateRepository;
        }

        public bool IsVATRateValid(decimal rate, string country = "Austria")
        {
            List<CountryRate> countryRates = _countryRateRepository.GetCountryValidRates(country);

            foreach (CountryRate countryRate in countryRates) 
            { 
                if(rate == countryRate.VATRate)
                    return true;
            }

            string rates = string.Join(", ", countryRates.Select(countryRate => countryRate.VATRate));

            _logger.Error($"Invalid VAT Rate: {rate} for Country {country}. " +
                    $"The current valid rates are {rates}.");

            throw new ArgumentException($"Invalid VAT Rate: {rate} for Country {country}. " +
                    $"The current valid rates are {rates}.");
        }

        public string IsNetGrossVATValid(CalculatorDTO values)
        {
            string baseValue = string.Empty;
            int count = 0;

            if (values.Net.HasValue && values.Net != 0)
            {
                baseValue = ValueConstants.NET;
                count++;
            }

            if (values.Gross.HasValue && values.Gross != 0)
            {
                baseValue = ValueConstants.GROSS;
                count++;
            }

            if (values.VAT.HasValue && values.VAT != 0)
            {
                baseValue = ValueConstants.VAT;
                count++;
            }

            if(count > 1)
            {
                _logger.Error($"Invalid Input. Only one of the Net, Gross, VAT values should be filled.");
                throw new ArgumentException($"Invalid Input. Only one of the Net, Gross, VAT values should be filled.");
            }
            else if (count == 0)
            {
                _logger.Error($"Invalid Input. At least one of the Net, Gross, VAT values should be filled and different of 0.");
                throw new ArgumentException($"Invalid Input. At least one of the Net, Gross, VAT values should be filled and different of 0.");
            }
            else
                return baseValue;
        }
    }
}
