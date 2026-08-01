namespace BankApi.Contracts.Currency
{
    public record CurrencyRes(Guid id , string name,string code,bool status,bool defaultCurrency,bool baseCurrency);
  
}
