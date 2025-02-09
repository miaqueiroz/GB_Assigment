using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GB_Assigment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(
            ICalculatorService calculatorService
        )
        {
            _calculatorService = calculatorService;
        }

        [SwaggerOperation("Calculate Net, Gross, VAT amounts for purchases.")]
        [HttpPost("calculateValues")]
        public IActionResult CalculateValues([FromBody] CalculatorDTO values)
        {
            try
            {
                CalculatorDTO results = _calculatorService.CalculateValues(values);

                return Ok(results);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
