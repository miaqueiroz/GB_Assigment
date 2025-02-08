
using GB_Assigment_Application.DTOs;
using GB_Assigment_Domain.Models;

namespace GB_Assigment_Application.Interfaces
{
    public interface ICalculatorService
    {
        CalculatorDTO CalculateValues(CalculatorDTO values);
    }
}
