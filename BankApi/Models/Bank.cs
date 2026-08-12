namespace BankApi.Models
{
    public class Bank
    {
      public Guid ID             { get; set; }  
      public string LookupCode   { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
      public string Abbreviation {  get; set; }=string.Empty;
      public Guid   CurrencyID   { get; set; }  = Guid.Empty;
        public string SwiftCode { get; set; } = string.Empty;
      public string Address      {  get; set; }= string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public bool Active { get; set; }
        public Currency Currency { get; set; } = default;
        //"AccountID").ID
    }
}
