using BankApi.Enums;

namespace BankApi.Models
{
    public class Facility
    {
        public Guid ID { get; set; }
        public string AccountNumber { get; set; } = default!;
        public int FacilityType { get; set; }
        public Guid PartyID { get; set; }
        public Guid CurrencyID { get; set; }
        public Party Party { get; set; } = default!;
        public Currency Currency { get; set; } = default!;
    }
}
