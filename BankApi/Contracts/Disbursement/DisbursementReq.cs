using BankApi.Models;

namespace BankApi.Contracts.Disbursement
{
    public record DisbursementReq(
Guid facilityID,
Guid contractID,
decimal amount,
DateTime disbursementDate,
int disbursementMethod,
string comments
        )
    {
    }
}
