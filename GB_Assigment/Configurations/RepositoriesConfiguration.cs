using GB_Assigment_Domain.Interfaces;
using GB_Assigment_Infrastructure.Repositories;

namespace GB_Assigment.Configurations
{
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
