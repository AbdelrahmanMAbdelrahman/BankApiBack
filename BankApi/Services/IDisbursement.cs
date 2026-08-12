using BankApi.Contracts.Disbursement;
using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Utils;

namespace BankApi.Services
{
    public interface IDisbursement
    {
        Task<Result<DisbursementRes>> createDisbursement(DisbursementReq req, CancellationToken ct);
        Task<Result> deleteDisbursement(Guid id, CancellationToken ct);
        Task<Result<PaginatedList<DisbursementRes>>> getAll(PaginatedReq req, CancellationToken ct);
        Task<Result<DisbursementRes>> getDisbursement(Guid id, CancellationToken ct);
        Task<Result<PaginatedList<DisbursementRes>>> Search(DisbursementSearch search, PaginatedReq req, CancellationToken ct);
        Task<Result> updateDisbursement(DisbursementReq req, Guid id, CancellationToken ct);
    }
}
