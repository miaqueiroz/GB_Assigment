using GB_Assigment_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GB_Assigment_Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class Context : DbContext
    {
        public DbSet<CountryRate> CountryRates { get; set; }

        public Context() { }
    }
}
