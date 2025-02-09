using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Interfaces;
using GB_Assigment_Application.Services;
using GB_Assigment_Domain.Constants;
using GB_Assigment_Tests.Arranges;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace GB_Assigment_Tests.Application.Services
{
    public class CalculatorServiceTests
    {
        private readonly IValidationService _validationServiceMock;
        private readonly CalculatorService _calculatorServiceMock;

        public CalculatorServiceTests() 
        {
            _validationServiceMock = Substitute.For<IValidationService>();
            _calculatorServiceMock = new CalculatorService(_validationServiceMock);
        }

        #region CalculateValues

        [Fact(DisplayName = "CalculateValues returns BadRequest when VAT rate is invalid.")]
        public void CalculateValues_ReturnBadRequest_InvalidRate()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidRate();

            _validationServiceMock.IsVATRateValid(dto.VATRate)
                .Throws(new ArgumentException("Test error."));

            Assert.Throws<ArgumentException>(() => _calculatorServiceMock.CalculateValues(dto));
        }
        
        [Fact(DisplayName = "CalculateValues returns BadRequest when Net,Gross,VAT are 0.")]
        public void CalculateValues_ReturnBadRequest_InvalidNetGrossVAT()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidNetGrossVat();

            _validationServiceMock.IsVATRateValid(dto.VATRate)
                .Throws(new ArgumentException("Test error."));

            Assert.Throws<ArgumentException>(() => _calculatorServiceMock.CalculateValues(dto));
        }

        [Fact(DisplayName = "CalculateValues returns BadRequest when more than one value was input.")]
        public void CalculateValues_ReturnBadRequest_MoreThanOneValueInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestMoreThanOneInput();

            _validationServiceMock.IsVATRateValid(dto.VATRate).Returns(true);
            _validationServiceMock.IsNetGrossVATValid(dto)
                .Throws(new ArgumentException("Test error."));

            Assert.Throws<ArgumentException>(() => _calculatorServiceMock.CalculateValues(dto));
        }

        [Fact(DisplayName = "CalculateValues returns OK with NET input.")]
        public void CalculateValues_ReturnsOK_NetInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputNet();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _validationServiceMock.IsVATRateValid(dtoInput.VATRate).Returns(true);
            _validationServiceMock.IsNetGrossVATValid(dtoInput).Returns(ValueConstants.NET);

            CalculatorDTO result = _calculatorServiceMock.CalculateValues(dtoInput);

            Assert.Equal(result.VAT, dtoOutput.VAT);
            Assert.Equal(result.Gross, dtoOutput.Gross);
        }

        [Fact(DisplayName = "CalculateValues returns OK with GROSS input.")]
        public void CalculateValues_ReturnsOK_GrossInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputGross();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _validationServiceMock.IsVATRateValid(dtoInput.VATRate).Returns(true);
            _validationServiceMock.IsNetGrossVATValid(dtoInput).Returns(ValueConstants.GROSS);

            CalculatorDTO result = _calculatorServiceMock.CalculateValues(dtoInput);

            Assert.Equal(result.Net, dtoOutput.Net);
            Assert.Equal(result.VAT, dtoOutput.VAT);
        }

        [Fact(DisplayName = "CalculateValues returns OK with VAT input.")]
        public void CalculateValues_ReturnsOK_VATInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputVAT();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _validationServiceMock.IsVATRateValid(dtoInput.VATRate).Returns(true);
            _validationServiceMock.IsNetGrossVATValid(dtoInput).Returns(ValueConstants.VAT);

            CalculatorDTO result = _calculatorServiceMock.CalculateValues(dtoInput);

            Assert.Equal(result.Net, dtoOutput.Net);
            Assert.Equal(result.Gross, dtoOutput.Gross);
        }
        
        #endregion
    }
}
