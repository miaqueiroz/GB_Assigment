
namespace GB_Assigment_Domain.Models
{
    public class CountryRate
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public decimal VATRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
