using BankApi.Enums;

namespace BankApi.Contracts.Contract
{
    public record ContractReq
 (
        string partyName,
        string contractNumber,
        EnContractType contractType ,
        bool iSLetter ,
        EnLeasingType leasingType ,
        DateTime endDate,
        DateTime startDate,
        Guid partyID
 );
}
