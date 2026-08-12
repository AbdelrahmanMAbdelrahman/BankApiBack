namespace BankApi.Contracts.Bank
{
    public record BankSearch(
        Guid? currencyID,
        string? address,
        string? phone,
        string? fax,
        string? eMail,
        bool? active
        );
    
    
}
