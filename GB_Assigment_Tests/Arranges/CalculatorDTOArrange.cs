
using GB_Assigment_Application.DTOs;

namespace GB_Assigment_Tests.Arranges
{
    public static class CalculatorDTOArrange
    {
        public static CalculatorDTO GetBadRequestInvalidRate()
        {
            return new CalculatorDTO
            {
                VATRate = 11
            };
        }

        public static CalculatorDTO GetBadRequestInvalidNetGrossVat()
        {
            return new CalculatorDTO
            {
                VATRate = 13
            };
        }

        public static CalculatorDTO GetBadRequestMoreThanOneInput()
        {
            return new CalculatorDTO
            {
                Net = 123,
                Gross = 555,
                VATRate = 13
            };
        }

        public static CalculatorDTO GetOkRequestExpected()
        {
            return new CalculatorDTO
            {
                Net = 123,
                Gross = (decimal)138.99,
                VAT = (decimal)15.99,
                VATRate = 13
            };
        }

        public static CalculatorDTO GetOkRequestInputNet()
        {
            return new CalculatorDTO
            {
                Net = 123,
                VATRate = 13
            };
        }

        public static CalculatorDTO GetOkRequestInputGross()
        {
            return new CalculatorDTO
            {
                Gross = (decimal)138.99,
                VATRate = 13
            };
        }

        public static CalculatorDTO GetOkRequestInputVAT()
        {
            return new CalculatorDTO
            {
                VAT = (decimal)15.99,
                VATRate = 13
            };
        }
    }
}
