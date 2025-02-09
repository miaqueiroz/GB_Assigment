using GB_Assigment.Controllers;
using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Interfaces;
using GB_Assigment_Tests.Arranges;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace GB_Assigment_Tests.API.Controllers
{
    public class CalculatorControllerTests
    {
        private readonly ICalculatorService _serviceMock;
        private readonly CalculatorController _controllerMock;

        public CalculatorControllerTests()
        {
            _serviceMock = Substitute.For<ICalculatorService>();
            _controllerMock = new CalculatorController(_serviceMock);
        }

        #region CalculateValues

        [Fact(DisplayName = "CalculateValues returns BadRequest when VAT rate is invalid.")]
        public void CalculateValues_ReturnBadRequest_InvalidRate()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidRate();
            _serviceMock.CalculateValues(dto)
                .Throws(new ArgumentException("Test error."));

            IActionResult result = _controllerMock.CalculateValues(dto);

            BadRequestObjectResult badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Test error.", badRequest.Value);
        }

        [Fact(DisplayName = "CalculateValues returns BadRequest when Net,Gross,VAT are 0.")]
        public void CalculateValues_ReturnBadRequest_InvalidNetGrossVAT()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestInvalidNetGrossVat();
            _serviceMock.CalculateValues(dto)
                .Throws(new ArgumentException("Test error."));

            IActionResult result = _controllerMock.CalculateValues(dto);

            BadRequestObjectResult badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Test error.", badRequest.Value);
        }

        [Fact(DisplayName = "CalculateValues returns BadRequest when more than one value was input.")]
        public void CalculateValues_ReturnBadRequest_MoreThanOneValueInput()
        {
            CalculatorDTO dto = CalculatorDTOArrange.GetBadRequestMoreThanOneInput();
            _serviceMock.CalculateValues(dto)
                .Throws(new ArgumentException("Test error."));

            IActionResult result = _controllerMock.CalculateValues(dto);

            BadRequestObjectResult badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Test error.", badRequest.Value);
        }

        [Fact(DisplayName = "CalculateValues returns OK with NET input.")]
        public void CalculateValues_ReturnsOK_NetInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputNet();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _serviceMock.CalculateValues(dtoInput).Returns(dtoOutput);

            IActionResult result = _controllerMock.CalculateValues(dtoInput);

            OkObjectResult okRequest = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(okRequest.Value, dtoOutput);
        }

        [Fact(DisplayName = "CalculateValues returns OK with GROSS input.")]
        public void CalculateValues_ReturnsOK_GrossInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputGross();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _serviceMock.CalculateValues(dtoInput).Returns(dtoOutput);

            IActionResult result = _controllerMock.CalculateValues(dtoInput);

            OkObjectResult okRequest = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(okRequest.Value, dtoOutput);
        }

        [Fact(DisplayName = "CalculateValues returns OK with VAT input.")]
        public void CalculateValues_ReturnsOK_VATInput()
        {
            CalculatorDTO dtoInput = CalculatorDTOArrange.GetOkRequestInputVAT();
            CalculatorDTO dtoOutput = CalculatorDTOArrange.GetOkRequestExpected();

            _serviceMock.CalculateValues(dtoInput).Returns(dtoOutput);

            IActionResult result = _controllerMock.CalculateValues(dtoInput);

            OkObjectResult okRequest = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(okRequest.Value, dtoOutput);
        }

        #endregion
    }
}
