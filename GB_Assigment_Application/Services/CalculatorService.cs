using GB_Assigment_Application.DTOs;
using GB_Assigment_Application.Interfaces;
using GB_Assigment_Domain.Constants;
using GB_Assigment_Domain.Models;

namespace GB_Assigment_Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IValidationService _validationService; 

        public CalculatorService(
            IValidationService validationService
        ) 
        {  
            _validationService = validationService;
        }

        #region Public Methods

        public CalculatorDTO CalculateValues(CalculatorDTO values)
        {
            if (_validationService.IsVATRateValid(values.VATRate))
            {
                string baseValue = _validationService.IsNetGrossVATValid(values);

                switch (baseValue)
                {
                    case ValueConstants.NET:
                        return values = this.CalculateValuesBasedOnNet(values);

                    case ValueConstants.GROSS:
                        return values = this.CalculateValuesBasedOnGross(values);

                    case ValueConstants.VAT:
                        return values = this.CalculateValuesBasedOnVAT(values);
                }
            }

            return values;
        }

        #endregion

        #region Private Methods

        private CalculatorDTO CalculateValuesBasedOnNet(CalculatorDTO values)
        {
            values.VAT = this.CalculateVAT((decimal)values.Net, values.VATRate);
            values.Gross = this.CalculateGross((decimal)values.Net, (decimal)values.VAT);

            return values;
        }

        private CalculatorDTO CalculateValuesBasedOnGross(CalculatorDTO values)
        {
            values.Net = this.CalculateNetWithGross((decimal)values.Gross, values.VATRate);
            values.VAT = this.CalculateVAT((decimal)values.Net, values.VATRate);

            return values;
        }

        private CalculatorDTO CalculateValuesBasedOnVAT(CalculatorDTO values)
        {
            values.Net = this.CalculateNetWithVAT((decimal)values.VAT, values.VATRate);
            values.Gross = this.CalculateGross((decimal)values.Net, (decimal)values.VAT);

            return values;
        }

        private decimal CalculateNetWithGross(decimal gross, decimal rate)
        {
            return Math.Round(gross / (1 + (rate / 100)), 2);
        }

        private decimal CalculateNetWithVAT(decimal vat, decimal rate)
        {
            return Math.Round(vat / (rate / 100), 2);
        }

        private decimal CalculateGross(decimal net, decimal vat) 
        {
            return Math.Round(net + vat, 2);
        }

        private decimal CalculateVAT(decimal net, decimal rate) 
        { 
            return Math.Round(net * (rate / 100), 2);
        }

        #endregion
    }
}
