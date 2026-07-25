using BankApi.Enums;

namespace BankApi.Contracts.Contract
{
    public record ContractRes
 (
        Guid ID,
        string partyName,
        string contractNumber,
        string contractType,
        bool iSLetter,
        string leasingType,
        DateTime endDate,
        DateTime startDate,
        Guid partyID
 );
}
