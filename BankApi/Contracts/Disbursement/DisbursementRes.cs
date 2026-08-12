using BankApi.Models;

namespace BankApi.Contracts.Disbursement
{
public record DisbursementRes(
Guid id,
Guid  facilityID,
string facility,//accountNumber
Guid contractID,
string contract ,//contractNumber
decimal amount,
DateTime disbursementDate,
string comments,
bool posted,
bool reviewed,
int disbursementMethod
        );
    
}
