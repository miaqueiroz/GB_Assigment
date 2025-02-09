using GB_Assigment_Application.DTOs;
using GB_Assigment_Tests.Arranges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Assigment_Tests.Application.DTOs
{
    public class CalculatorDTOTests
    {
        [Fact]
        public void CalculatorDTO_SetAndGetOK()
        {
            CalculatorDTO dto = new CalculatorDTO();
            CalculatorDTO dtoExpected = CalculatorDTOArrange.GetOkRequestExpected();

            dto.VATRate = dtoExpected.VATRate;
            dto.VAT = dtoExpected.VAT;
            dto.Gross = dtoExpected.Gross;
            dto.Net = dtoExpected.Net;

            Assert.Equal(dtoExpected.VATRate, dto.VATRate);
            Assert.Equal(dtoExpected.VAT, dto.VAT);
            Assert.Equal(dtoExpected.Gross, dto.Gross);
            Assert.Equal(dtoExpected.Net, dto.Net);
        }
    }
}
