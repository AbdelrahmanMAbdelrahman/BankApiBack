using BankApi.Errors;

namespace BankApi.Contracts.Currency
{
    public record CurrencyReq(string name, string code, bool status, bool defaultCurrency, bool baseCurrency)
    {
        internal async Task<Result<CurrencyRes>> CreateCurrency(CurrencyReq currency, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
