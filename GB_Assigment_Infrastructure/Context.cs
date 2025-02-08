using GB_Assigment_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GB_Assigment_Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<CountryRate> CountryRates { get; set; }

        public Context() { }
    }
}
