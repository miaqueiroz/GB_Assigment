using GB_Assigment_Application.Interfaces;
using GB_Assigment_Application.Services;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace GB_Assigment.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            if (services == null) 
            { 
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddSingleton(Log.Logger);
        }
    }
}
