namespace BankApi.Contracts.Bank
{
    public record BankReq(
        string lookupCode,
        string description,
        string abbreviation,
        Guid currencyID,
        string address,
        string phone,
        string fax,
        string eMail,
        bool   active,
        string swiftCode
        );
  
}
