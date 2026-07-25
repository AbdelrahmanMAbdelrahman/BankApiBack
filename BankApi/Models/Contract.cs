using BankApi.Enums;

namespace BankApi.Models
{
    public class Contract
    {
        public Guid ID { get; set; }
        public Guid PartyID { get; set; } 
        public string ContractNumber { get; set; } = default!;
        public EnContractType ContractType { get; set; } 
        public bool ISLetter { get; set; } = default!;
        public EnLeasingType LeasingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public Party Party { get; set; }= default!;
    }
}
