
using GB_Assigment_Application.DTOs;
using GB_Assigment_Domain.Models;

namespace GB_Assigment_Application.Interfaces
{
    public interface IValidationService
    {
        bool IsVATRateValid(decimal rate, string country = "Austria");
        string IsNetGrossVATValid(CalculatorDTO values);
    }
}
