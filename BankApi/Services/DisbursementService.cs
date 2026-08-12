using BankApi.Contracts.Contract;
using BankApi.Contracts.Disbursement;
using BankApi.Contracts.Pagination;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using BankApi.Utils;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class DisbursementService (DatabaseContext DBContext): IDisbursement
    {
        public async Task<Result<DisbursementRes>> createDisbursement(DisbursementReq req, CancellationToken ct)
        {
            Contract? contract =await DBContext.Contracts.FindAsync(req.contractID,ct);
            if (contract is null) return Result.Failure<DisbursementRes>(DisbursementErrors.ContractNotFound);
            Facility? facility =await DBContext.Facilities.FindAsync(req.facilityID,ct);
            if (facility is null) return Result.Failure<DisbursementRes>(DisbursementErrors.FacilityNotFound);
            Disbursement disbursement = req.Adapt<Disbursement>();
            DBContext.Disbursements.Add(disbursement);
            if(await Commit(ct))
            {
                DisbursementRes res =disbursement.Adapt<DisbursementRes>();
                return Result.Success(res);
            }
            return Result.Failure<DisbursementRes>(DisbursementErrors.BadRequest);
        }

        public async Task<Result> deleteDisbursement(Guid id, CancellationToken ct)
        {
            Disbursement? disbursement = await DBContext.Disbursements.FindAsync(id, ct);
            if (disbursement is null) return Result.Failure(DisbursementErrors.NotFound);
            DBContext.Disbursements.Remove(disbursement);
            return await Commit(ct) ?
                Result.Success() :
                Result.Failure(DisbursementErrors.InternalServerError);
        }

        public async Task<Result<PaginatedList<DisbursementRes>>> getAll(PaginatedReq req, CancellationToken ct)
        {
            IQueryable<DisbursementRes> disbursements = DBContext.Disbursements
                .
            Select(d =>
                new DisbursementRes(
                    d.ID,
                    d.FacilityID,
                    d.Facility.AccountNumber,
                    d.ContractID,
                    d.Contract.ContractNumber,
                    d.Amount,
                    d.DisbursementDate,
                    d.Comments,
                    d.Posted,
                    d.Reviewed,
                    d.DisbursementMethod
                    ));
            PaginatedList<DisbursementRes> paginated =await PaginatedList<DisbursementRes>.
                Create(disbursements, req.pageSize, req.pageNumber);
            return paginated.TotalPages > 0 ?
                Result.Success(paginated) :
                Result.Failure<PaginatedList<DisbursementRes>>(DisbursementErrors.NotFound);
        }

        public async Task<Result<DisbursementRes>> getDisbursement(Guid id, CancellationToken ct)
        {
            DisbursementRes? disbursement =await DBContext.Disbursements
                .Where(d=>d.ID==id)
                .Select(
                d=>new  DisbursementRes(
                    d.ID,
                    d.FacilityID,
                    d.Facility.AccountNumber,
                    d.ContractID,
                    d.Contract.ContractNumber,
                    d.Amount,
                    d.DisbursementDate,
                    d.Comments,
                    d.Posted,
                    d.Reviewed,
                    d.DisbursementMethod
                    )
                ).SingleOrDefaultAsync();

            if (disbursement is null) return Result.Failure<DisbursementRes>(DisbursementErrors.NotFound);
            DisbursementRes res = disbursement.Adapt<DisbursementRes>();
            return Result.Success(res);
        }

        public async Task<Result<PaginatedList<DisbursementRes>>> Search(DisbursementSearch search, PaginatedReq req, CancellationToken ct)
        {
            IQueryable<Disbursement> query = DBContext.Disbursements;
            if (search.facilityID.HasValue)
            {
                query = query.Where(d => d.FacilityID == search.facilityID);
            }
            if (search.contractID.HasValue)
            {
                query = query.Where(d => d.ContractID == search.contractID);
            }
            if (search.disbursementDate.HasValue)
            {
                query = query.Where(d => d.DisbursementDate == search.disbursementDate);
            }
            if (search.amount.HasValue)
            {
                query = query.Where(d => d.Amount == search.amount);
            }
            if (search.disbursementMethod.HasValue)
            {
                query = query.Where(d => d.DisbursementMethod == search.disbursementMethod);
            }

            IQueryable<DisbursementRes> queryRes = query.Select(d =>
            new DisbursementRes(
                d.ID,
                    d.FacilityID,
                    d.Facility.AccountNumber,
                    d.ContractID,
                    d.Contract.ContractNumber,
                    d.Amount,
                    d.DisbursementDate,
                    d.Comments,
                    d.Posted,
                    d.Reviewed,
                    d.DisbursementMethod
                ));
            PaginatedList<DisbursementRes> paginated =await PaginatedList<DisbursementRes>
                .Create(queryRes, req.pageSize, req.pageNumber);

            return paginated.TotalPages > 0 ?
                Result.Success(paginated) :
                Result.Failure<PaginatedList<DisbursementRes>>(DisbursementErrors.NotFound);
        }

        public async Task<Result> updateDisbursement(DisbursementReq req, Guid id, CancellationToken ct)
        {
            Contract? contract = await DBContext.Contracts.FindAsync(req.contractID, ct);
            if (contract is null) return Result.Failure<DisbursementRes>(DisbursementErrors.ContractNotFound);
            Facility? facility = await DBContext.Facilities.FindAsync(req.facilityID, ct);
            if (facility is null) return Result.Failure<DisbursementRes>(DisbursementErrors.FacilityNotFound);
            Disbursement? disbursement = await DBContext.Disbursements.FindAsync(id, ct);
            if (disbursement is null) return Result.Failure(DisbursementErrors.NotFound);
            req.Adapt(disbursement);
            if (await Commit(ct)) return Result.Success();
            return Result.Failure(DisbursementErrors.BadRequest);
        }
        private async Task<bool> Commit(CancellationToken ct)
        {
            return await DBContext.SaveChangesAsync(ct) > 0;
        }
    }
}
