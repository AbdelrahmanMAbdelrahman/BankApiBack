namespace BankApi.Models
{
    public class Disbursement
    {
       public Guid ID { get; set; }   
       public Guid FacilityID { get; set; }
       public Facility Facility { get; set; } = default!;
       public Guid ContractID { get; set; }
       public Contract Contract { get; set; } = default!;
       public decimal Amount { get; set; }
       public DateTime DisbursementDate { get; set; }
       public string Comments { get; set; } = default!;
       public bool Posted { get; set; }
       public bool Reviewed { get; set; }
       public int DisbursementMethod { get; set; }
    }
}
