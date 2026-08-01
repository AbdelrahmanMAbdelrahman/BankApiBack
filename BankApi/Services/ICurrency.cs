using BankApi.Contracts.Currency;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface ICurrency
    {
        Task<Result<CurrencyRes>> CreateCurrency(CurrencyReq currencyReq, CancellationToken ct);
        Task<Result> DeleteCurrency(Guid id, CancellationToken ct);
        Task<Result<List<CurrencyRes>>> GetAllCurrencies(CancellationToken ct);
        Task<Result<CurrencyRes>> GetCurrency(Guid id, CancellationToken ct);
        Task<Result> UpdateCurrency(CurrencyReq currencyReq, Guid id, CancellationToken ct);
    }
}
