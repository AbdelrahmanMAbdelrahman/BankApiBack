using System.Numerics;

namespace BankApi.Contracts.Bank
{
    public record BankRes(
        Guid   id,
        string lookupCode,
        string description,
        string abbreviation,
        Guid currencyID,
        string currency,
        string swiftCode,
        string address,
        string phone,
        string fax,
        string eMail,
        bool   active
        );
    
    
}
