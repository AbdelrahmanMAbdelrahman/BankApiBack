namespace BankApi.Models
{
    public class Currency
    {
        public Guid ID { get; set; }
        public string  Name { get; set;   }=default!;
        public string Code { get; set; } = default!;
        public bool Status { get; set; }
        public bool DefaultCurrency {  get; set; }
        public bool BaseCurrency {  get; set; }
    }
}
