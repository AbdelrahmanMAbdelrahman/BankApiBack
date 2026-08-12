using BankApi.Contracts.Bank;
using BankApi.Contracts.Pagination;

using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using BankApi.Utils;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BankApi.Services
{
    public class BankService(DatabaseContext DBContext):IBank
    {
        public async Task<Result<BankRes>> createBank(BankReq req, CancellationToken ct)
        {
            Currency? currency = await DBContext.Currencies.FindAsync(req.currencyID, ct);
            if (currency is null) return Result.Failure<BankRes>(BankErrors.CurrencyNotFound);
            
            Bank Bank = req.Adapt<Bank>();
            DBContext.Banks.Add(Bank);
            if (await Commit(ct))
            {
                BankRes res = Bank.Adapt<BankRes>();
                return Result.Success(res);
            }
            return Result.Failure<BankRes>(BankErrors.BadRequest);
        }

        public async Task<Result> deleteBank(Guid id, CancellationToken ct)
        {
            Bank? Bank = await DBContext.Banks.FindAsync(id, ct);
            if (Bank is null) return Result.Failure(BankErrors.NotFound);
            DBContext.Banks.Remove(Bank);
            return await Commit(ct) ?
                Result.Success() :
                Result.Failure(BankErrors.InternalServerError);
        }

        public async Task<Result<PaginatedList<BankRes>>> getAll(PaginatedReq req, CancellationToken ct)
        {
            IQueryable<BankRes> Banks = DBContext.Banks
                .
            Select(d =>
                new BankRes(
                    d.ID,
                    d.LookupCode,
                    d.Description,
                    d.Abbreviation,
                    d.CurrencyID,
                    d.Currency.Name,
                    d.SwiftCode,
                    d.Address,
                    d.Phone,
                    d.Fax,
                    d.EMail,
                    d.Active
                    ));
            PaginatedList<BankRes> paginated = await PaginatedList<BankRes>.
                Create(Banks, req.pageSize, req.pageNumber);
            return paginated.TotalPages > 0 ?
                Result.Success(paginated) :
                Result.Failure<PaginatedList<BankRes>>(BankErrors.NotFound);
        }

        public async Task<Result<BankRes>> getBank(Guid id, CancellationToken ct)
        {
            BankRes? Bank = await DBContext.Banks
                .Where(d => d.ID == id)
                .Select(
                d => new BankRes(
                    d.ID,
                    d.LookupCode,
                    d.Description,
                    d.Abbreviation,
                    d.CurrencyID,
                    d.Currency.Name,
                    d.SwiftCode,
                    d.Address,
                    d.Phone,
                    d.Fax,
                    d.EMail,
                    d.Active
                    )
                ).SingleOrDefaultAsync();

            if (Bank is null) return Result.Failure<BankRes>(BankErrors.NotFound);
            BankRes res = Bank.Adapt<BankRes>();
            return Result.Success(res);
        }

        public async Task<Result<PaginatedList<BankRes>>> Search(BankSearch search, PaginatedReq req, CancellationToken ct)
        {
            IQueryable<Bank> query = DBContext.Banks;
            if (search.currencyID.HasValue)
            {
                query = query.Where(d => d.CurrencyID == search.currencyID);
            }
            if (!search.phone.IsNullOrEmpty())
            {
                query = query.Where(d => d.Phone == search.phone);
            }
            if (!search.fax.IsNullOrEmpty())
            {
                query = query.Where(d => d.Fax == search.fax);
            }
            if (!search.eMail.IsNullOrEmpty())
            {
                query = query.Where(d => d.EMail == search.eMail);
            }
          

            IQueryable<BankRes> queryRes = query.Select(d =>
            new BankRes(
                d.ID,
                    d.LookupCode,
                    d.Description,
                    d.Abbreviation,
                    d.CurrencyID,
                    d.Currency.Name,
                    d.SwiftCode,
                    d.Address,
                    d.Phone,
                    d.Fax,
                    d.EMail,
                    d.Active
                ));
            PaginatedList<BankRes> paginated = await PaginatedList<BankRes>
                .Create(queryRes, req.pageSize, req.pageNumber);

            return paginated.TotalPages > 0 ?
                Result.Success(paginated) :
                Result.Failure<PaginatedList<BankRes>>(BankErrors.NotFound);
        }

        public async Task<Result> updateBank(BankReq req, Guid id, CancellationToken ct)
        {
            Currency? contract = await DBContext.Currencies.FindAsync(req.currencyID, ct);
            if (contract is null) return Result.Failure<BankRes>(BankErrors.CurrencyNotFound);
           
            Bank? Bank = await DBContext.Banks.FindAsync(id, ct);
            if (Bank is null) return Result.Failure(BankErrors.NotFound);
            req.Adapt(Bank);
            if (await Commit(ct)) return Result.Success();
            return Result.Failure(BankErrors.BadRequest);
        }
        private async Task<bool> Commit(CancellationToken ct)
        {
            return await DBContext.SaveChangesAsync(ct) > 0;
        }
    }
}
