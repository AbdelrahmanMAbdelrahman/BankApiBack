namespace BankApi.Contracts.Disbursement
{
    public record DisbursementSearch(
Guid? facilityID,
Guid? contractID,
decimal? amount,
DateTime? disbursementDate,
int? disbursementMethod
        );
  
}
