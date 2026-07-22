namespace BankApi.Models
{
    public class Party
    {
 public Guid ID { get; set; }
        public string internalCode { get; set; } = default!;
 public string partyGroupName { get; set; } = default!;
        public string active { get; set; } = default!;
        public string nativeName { get; set; } = default!;
        public string name { get; set; } = default!;
        public string partyCode { get; set; } = default!;
    }
}
