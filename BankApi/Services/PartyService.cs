using BankApi.Contracts.Party;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Services
{
    public class PartyService(DatabaseContext database):IParty
    {
        public async Task<Result<PartyRes>> AddNewParty(PartyReq req, CancellationToken ct)
        {
            Party emp = req.Adapt<Party>();
            await database.Parties.AddAsync(emp);
            PartyRes res =  emp.Adapt < PartyRes >();
            
            return await Commit() ? Result.Success(res) : Result.Failure<PartyRes>(PartyErrors.BadRequest);
        }

        public async Task<bool> Commit()
        {
            return await database.SaveChangesAsync() > 0;
        }

        public async Task<Result> DeleteParty(Guid id, CancellationToken ct)
        {
            var party = await database.Parties.FindAsync(id);
            if (party is null) return Result.Failure(PartyErrors.NotFound);
            var res =   database.Parties.Remove(party);
            return await Commit()?Result.Success():Result.Failure(PartyErrors.BadRequest);
        }

        public async Task<Result<List<PartyRes>>> GetAll(CancellationToken ct)
        {
            List<Party> emps = await database.Parties.ToListAsync();

            List<PartyRes> res = emps.Adapt<List<PartyRes>>();
            return res.Count() > 0 ? Result.Success(res) :
                Result.Failure<List<PartyRes>>(PartyErrors.NotFound);
        }

        public async Task<Result<PartyRes>> GetParty(Guid id, CancellationToken ct)
        {
            var emp = await database.Parties.FindAsync(id);
            if (emp is null) return Result.Failure<PartyRes>(PartyErrors.NotFound);
            PartyRes res = emp.Adapt<PartyRes>();
            return Result.Success(res);
        }

        public async Task<Result> UpdateParty(PartyReq req, Guid id, CancellationToken ct)
        {
            Party? emp = await database.Parties.FindAsync(id);
            if (emp is null) return Result.Failure(PartyErrors.NotFound);
            req.Adapt(emp);
            return await Commit() ? Result.Success() : Result.Failure(PartyErrors.BadRequest);
        }
    }
}
