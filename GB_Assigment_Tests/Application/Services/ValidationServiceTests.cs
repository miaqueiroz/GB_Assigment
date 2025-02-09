using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Services;
using GB_Assigment_Domain.Constants;
using GB_Assigment_Domain.Interfaces;
using GB_Assigment_Domain.Models;
using GB_Assigment_Tests.Arranges;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Serilog;

namespace GB_Assigment_Tests.Application.Services
{
    public class ValidationServiceTests
    {
        private readonly ILogger _loggerMock;
        private readonly ICountryRateRepository _countryRateRepositoryMock;
        private readonly ValidationService _validationServiceMock;

        public ValidationServiceTests() 
        {
            _loggerMock = Substitute.For<ILogger>();
            _countryRateRepositoryMock = Substitute.For<ICountryRateRepository>();
            _validationServiceMock = new ValidationService(_loggerMock, _countryRateRepositoryMock);
        }

        #region IsVATRateValid

        [Fact(DisplayName = "Returns ArgumentException when Rate is Invalid.")]
        public void IsVATRateValid_ThrowsArgumentException_InvalidRate()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidRate();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            Assert.Throws<ArgumentException>(() => _validationServiceMock.IsVATRateValid(dto.VATRate));
        }

        [Fact(DisplayName = "Returns true when Rate is Valid")]
        public void IsVATRateValid_ReturnTrue_ValidRate()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidNetGrossVat();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            bool result = _validationServiceMock.IsVATRateValid(dto.VATRate);

            Assert.True(result);
        }

        #endregion

        #region IsNetGrossVATValid

        [Fact(DisplayName = "Returns ArgumentException when no Input.")]
        public void IsNetGrossVATValid_ThrowsArgumentException_NoInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidNetGrossVat();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            Assert.Throws<ArgumentException>(() => _validationServiceMock.IsNetGrossVATValid(dto));
        }

        [Fact(DisplayName = "Returns NET when Net value is input and valid.")]
        public void IsNetGrossVATValid_ReturnNet_ValidNetInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetOkRequestInputNet();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            string result = _validationServiceMock.IsNetGrossVATValid(dto);

            Assert.Equal(ValueConstants.NET, result);
        }

        [Fact(DisplayName = "Returns GROSS when Gross value is input and valid.")]
        public void IsNetGrossVATValid_ReturnGross_ValidNetInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetOkRequestInputGross();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            string result = _validationServiceMock.IsNetGrossVATValid(dto);

            Assert.Equal(ValueConstants.GROSS, result);
        }

        [Fact(DisplayName = "Returns VAT when VAT value is input and valid.")]
        public void IsNetGrossVATValid_ReturnVAT_ValidNetInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetOkRequestInputVAT();
            List<CountryRate> rates = CountryRateArrange.GetExpectedRates();

            _countryRateRepositoryMock.GetCountryValidRates("Austria").Returns(rates);

            string result = _validationServiceMock.IsNetGrossVATValid(dto);

            Assert.Equal(ValueConstants.VAT, result);
        }

        #endregion
    }
}
