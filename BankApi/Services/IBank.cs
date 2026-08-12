using BankApi.Contracts.Bank;
using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Utils;

namespace BankApi.Services
{
    public interface IBank
    {
        Task<Result<BankRes>> createBank(BankReq req, CancellationToken ct);
        Task<Result> deleteBank(Guid id, CancellationToken ct);
        Task<Result<PaginatedList<BankRes>>> getAll(PaginatedReq req, CancellationToken ct);
        Task<Result<BankRes>> getBank(Guid id, CancellationToken ct);
        Task<Result<PaginatedList<BankRes>>> Search(BankSearch search, PaginatedReq req, CancellationToken ct);
        Task<Result> updateBank(BankReq req, Guid id, CancellationToken ct);
    }
}
