using GB_Assigment_Domain.Interfaces;
using GB_Assigment_Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace GB_Assigment.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICountryRateRepository, CountryRateRepository>();
        }
    }
}
