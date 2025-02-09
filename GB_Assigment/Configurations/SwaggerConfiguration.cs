using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace GB_Assigment.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GB Assigment",
                    Description = "Net, Gross, VAT Calculator",
                    Contact = new OpenApiContact{
                        Name = "Mayara Queiroz",
                        Email = "miaqueiroz_@hotmail.com"
                    }
                });            
            });
        }
    }
}
