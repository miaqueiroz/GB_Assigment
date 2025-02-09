
using GB_Assigment_Domain.Models;
using GB_Assigment_Tests.Arranges;

namespace GB_Assigment_Tests.Domain
{
    public class CountryRateTests
    {
        [Fact]
        public void CountryRate_SetAndGetOK()
        {
            CountryRate rate = new CountryRate();
            CountryRate rateExpected = CountryRateArrange.GetExpectedRate();

            rate.VATRate = rateExpected.VATRate;
            rate.Id = rateExpected.Id;
            rate.IsActive = rateExpected.IsActive;
            rate.UpdatedDate = rateExpected.UpdatedDate;
            rate.UpdatedBy = rateExpected.UpdatedBy;
            rate.Country = rateExpected.Country;

            Assert.Equal(rateExpected.VATRate, rate.VATRate);
            Assert.Equal(rateExpected.Id, rate.Id);
            Assert.Equal(rateExpected.IsActive, rate.IsActive);
            Assert.Equal(rateExpected.UpdatedDate, rate.UpdatedDate);
            Assert.Equal(rateExpected.UpdatedBy, rate.UpdatedBy);
            Assert.Equal(rateExpected.Country, rate.Country);
        }
    }
}
