using BankApi.Contracts.Currency;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Services
{
    public class CurrencyService(DatabaseContext database) : ICurrency
    {
        public async Task<Result<CurrencyRes>> CreateCurrency(CurrencyReq currencyReq, CancellationToken ct)
        {
            Currency currency = currencyReq.Adapt<Currency>();
            await database.Currencies.AddAsync(currency,ct);
            if(await Commit())
            {
                CurrencyRes res = currency.Adapt<CurrencyRes>();
                return Result.Success(res);
            }
            return Result.Failure<CurrencyRes>(CurrencyError.BadRequest);
        }

        public async Task<Result> DeleteCurrency(Guid id, CancellationToken ct)
        {
            Currency? currency = await database.Currencies.FindAsync(id, ct);
            if (currency is null) return Result.Failure(CurrencyError.NotFound);
             database.Currencies.Remove(currency);
            return await Commit()?
                Result.Success():
                Result.Failure(CurrencyError.BadRequest);
        }

        public async Task<Result<List<CurrencyRes>>> GetAllCurrencies(CancellationToken ct)
        {
            List<CurrencyRes> currencies = await database.Currencies.ProjectToType<CurrencyRes>().ToListAsync();
            if(currencies.Count==0)return Result.Failure<List<CurrencyRes>>(CurrencyError.NotFound);
            return Result.Success(currencies);

        }

        public async Task<Result<CurrencyRes>> GetCurrency(Guid id, CancellationToken ct)
        {
            Currency? currency = await database.Currencies.FindAsync(id, ct);
            if (currency is null) return Result.Failure<CurrencyRes>(CurrencyError.NotFound);
            CurrencyRes currencyRes = currency.Adapt<CurrencyRes>();
            return Result.Success(currencyRes);
        }

        public async Task<Result> UpdateCurrency(CurrencyReq currencyReq, Guid id, CancellationToken ct)
        {
            Currency? currency = await database.Currencies.FindAsync(id, ct);
            if (currency is null) return Result.Failure(CurrencyError.NotFound);
            currencyReq.Adapt(currency);
            return await Commit() ?
                Result.Success() :
                Result.Failure(CurrencyError.BadRequest);
        }
        private async Task<bool> Commit()
        {
            return await database.SaveChangesAsync() > 0;
        }
    }
}
