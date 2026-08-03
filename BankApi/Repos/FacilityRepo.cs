using BankApi.Contracts.Facility;
using BankApi.Contracts.Pagination;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Migrations;
using BankApi.Models;
using BankApi.Services;
using BankApi.Utils;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApi.Repos
{
    public class FacilityRepo(DatabaseContext database) : IFacility
    {
        public async Task<Result<FacilityRes>> CreateFacility(FacilityReq req, CancellationToken ct)
        {
            Party? party = await database.Parties.FindAsync(req.partyID);
            if (party is null)
            {
                return Result.Failure<FacilityRes>(PartyErrors.NotFound);
            }
           BankApi.Models. Currency? currency = await database.Currencies.FindAsync(req.currencyID);
            if (party is null)
            {
                return Result.Failure<FacilityRes>(CurrencyError.NotFound);
            }
            Facility fac = req.Adapt<Facility>();
            await database.Facilities.AddAsync(fac,ct);
            if (await Commit(ct)) {
                FacilityRes res =fac.Adapt<FacilityRes>();
               return Result.Success(res);
            }
               return Result.Failure<FacilityRes>(FacilityError.BadRequest);
        }

        public async Task<Result> DeleteFacility(Guid id, CancellationToken ct)
        {
            Facility? fac = await database.Facilities.FindAsync(id, ct);
            if(fac is null)
            {
                return Result.Failure(FacilityError.NotFound);
            }
            database.Facilities.Remove(fac);
            return await Commit(ct)?
                Result.Success():
                Result.Failure(FacilityError.InternalServerError);
        }

        public async Task<Result<PaginatedList<FacilityRes>>> GetFacilities(PaginatedReq req,CancellationToken ct)
        {
            IQueryable<FacilityRes> facRes =  database.Facilities
                .Select(
                f => new FacilityRes(
                    f.ID,
                    f.AccountNumber,
                    f.PartyID,
                    f.CurrencyID,
                    f.FacilityType,
                    f.Currency.Name,
                    f.Party.Name
                    )
                );
            PaginatedList<FacilityRes> facilities = await PaginatedList<FacilityRes>.Create(facRes,req.pageSize,req.pageNumber);
            return facilities.TotalPages>0 ?
                Result.Success(facilities) :
                Result.Failure<PaginatedList<FacilityRes>>(FacilityError.NotFound);
        }

        public async Task<Result<List<FacilityRes>>> GetFacilitiesPerCurrency(Guid currencyId, CancellationToken ct)
        {
            List<FacilityRes> facilities =await database.Facilities
                .Where(f=>f.CurrencyID==currencyId)
                .Select(
                f => new FacilityRes(
                    f.ID,
                    f.AccountNumber,
                    f.PartyID,
                    f.CurrencyID,
                    f.FacilityType,
                    f.Currency.Name,
                    f.Party.Name
                    )
                )
                .ToListAsync();
            return facilities.Any() ?
                Result.Success(facilities) :
                Result.Failure<List<FacilityRes>>(FacilityError.NotFound);
        }
        private   IQueryable<FacilityRes> GetFacilitiesQuer()
        {
            return   database.Facilities.Select(
                f => new FacilityRes(
                    f.ID,
                    f.AccountNumber,
                    f.PartyID,
                    f.CurrencyID,
                    f.FacilityType,
                    f.Currency.Name,
                    f.Party.Name
                    )
                );
        }

        public async Task<Result<List<FacilityRes>>> GetFacilitiesPerParty(Guid partyId, CancellationToken ct)
        {
          List< FacilityRes>facilities=await database.Facilities
                .Where(f=>f.PartyID==partyId)
                .Select(
                f => new FacilityRes(
                    f.ID,
                    f.AccountNumber,
                    f.PartyID,
                    f.CurrencyID,
                    f.FacilityType,
                    f.Currency.Name,
                    f.Party.Name
                    )
                )
                .ToListAsync();
            return facilities.Any()?
                Result.Success(facilities):
                Result.Failure<List<FacilityRes>>(FacilityError.NotFound);
        }

        public async Task<Result<FacilityRes>> GetFacility(Guid id, CancellationToken ct)
        {
         FacilityRes? facility=await database.Facilities
                 .Where(f=>f.ID==id)
                .Select(
                f => new FacilityRes(
                    f.ID,
                    f.AccountNumber,
                    f.PartyID,
                    f.CurrencyID,
                    f.FacilityType,
                    f.Currency.Name,
                    f.Party.Name
                    )
                ).SingleOrDefaultAsync(ct);
            if(facility is null)
            {
                return Result.Failure<FacilityRes>(FacilityError.NotFound);
            }
            return Result.Success(facility);

        }

        public async Task<Result> UpdateFacility(FacilityReq req, Guid id, CancellationToken ct)
        {
            Facility? fac = await database.Facilities.FindAsync(id, ct);
            if (fac is null)
            {
                return Result.Failure(FacilityError.NotFound);
            }
            Party? party = await database.Parties.FindAsync(req.partyID);
            if (party is null)
            {
                return Result.Failure(PartyErrors.NotFound);
            }
           BankApi.Models. Currency? currency = await database.Currencies.FindAsync(req.currencyID);
            if (party is null)
            {
                return Result.Failure(CurrencyError.NotFound);
            }
            req.Adapt(fac);
            return await Commit(ct) ?
                Result.Success() :
                Result.Failure(FacilityError.BadRequest);
        }
        private async Task<bool> Commit(CancellationToken ct)
        {
            return await database.SaveChangesAsync(ct) > 0;
        }
    }
}
