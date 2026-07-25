using BankApi.Contracts.Contract;
using BankApi.Contracts.Party;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using BankApi.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Repos
{
    public class ContractRepo(DatabaseContext context) : IContract
    {
        public async Task<Result<ContractRes>> createContract(ContractReq req, CancellationToken ct)
        {
            Party? party = await context.Parties.FindAsync(req.partyID);
            if (party is null) return Result.Failure<ContractRes>(ContractErrors.PartyNotFound);
            Contract contract = req.Adapt<Contract>();
            await context.AddAsync(contract);
            if( await Commit())
            {
                ContractRes res=contract.Adapt<ContractRes>();
                return Result.Success(res);
            }
            return Result.Failure<ContractRes>(ContractErrors.BadRequest);
        }

        public async Task<Result> DeleteContract(Guid id, CancellationToken ct)
        {
            Contract? contract =await context.Contracts.FindAsync(id);
            if(contract is null)return  Result.Failure<ContractRes>(ContractErrors.Notfound);
            context.Contracts.Remove(contract);
            return (await Commit()) ?
                 Result.Success() :
                 Result.Failure(ContractErrors.BadRequest);
        }

        public async Task<Result<ContractRes>> getContract(Guid id, CancellationToken ct)
        {
            ContractRes? contract =await  context.Contracts.Where(c=>c.ID==id).Select(
                c=>new ContractRes(
                    c.ID,
                    c.Party.Name,
                    c.ContractNumber,
                    c.ContractType.ToString(),
                    c.ISLetter,
                    c.LeasingType.ToString(),
                    c.EndDate,
                    c.StartDate,
                    c.PartyID
                    )).SingleAsync(ct);
            if (contract is null) return Result.Failure<ContractRes>(ContractErrors.Notfound);
            return Result.Success(contract);
        }

        public async Task<Result<List<ContractRes>>> getContracts(CancellationToken ct)
        {
            List<ContractRes> contracts =await context.Contracts
                .Select(c=>
                new ContractRes(
                    c.ID,
                    c.Party.Name,
                    c.ContractNumber,
                    c.ContractType.ToString(),
                    c.ISLetter,
                    c.LeasingType.ToString(),
                    c.EndDate,
                    c.StartDate,
                    c.PartyID
                    )).ToListAsync();
            if (contracts.Any())
            {
                //List<ContractRes> res =contracts.Adapt<List<ContractRes>>();
                return Result.Success(contracts);
            }
            return Result.Failure<List<ContractRes>>(ContractErrors.Notfound);
        }

        public async Task<Result> updateContract(ContractReq req, Guid id, CancellationToken ct)
        {
            Contract? contract = await context.Contracts.FindAsync(id);
            if (contract is null) return Result.Failure<ContractRes>(ContractErrors.Notfound);
            req.Adapt(contract);
            if(await Commit())
            {
                ContractRes res = contract.Adapt<ContractRes>();
                return Result.Success();
            }
            return Result.Failure(ContractErrors.BadRequest);
        }
        public async Task<bool> Commit()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Result<List<ContractRes>>> getContractsByParty(Guid partyID, CancellationToken ct)
        {
           List<ContractRes> contracts=await context.Contracts.Where(c=>c.PartyID==partyID)
                .Select(c => new ContractRes(
                    c.ID,
                    c.Party.Name,
                    c.ContractNumber,
                    c.ContractType.ToString(),
                    c.ISLetter,
                    c.LeasingType.ToString(),
                    c.EndDate,
                    c.StartDate,
                    c.PartyID
                    ))
                .ToListAsync(ct);
            if(contracts.Count() > 0)
            {
                //List<ContractRes> res = contracts.Adapt<List<ContractRes>>();
                return Result.Success(contracts);
            }
            return Result.Failure<List<ContractRes>>(ContractErrors.Notfound);
        }

        public async Task<Result<List<PartyRes>>> GetPartiesByContract(Guid id, CancellationToken ct)
        {
            List<PartyRes> parties=await context.Contracts.Where(c=>c.ID==id)
                .Select(
                c=>new PartyRes(
                    c.Party.ID,
                    c.Party.InternalCode,
                    c.Party.PartyGroupName,
                    c.Party.Active,
                    c.Party.NativeName,
                    c.Party.Name,
                    c.Party.PartyCode
                    )
                ).ToListAsync(ct);
            return parties.Any() ?
                Result.Success(parties) :
                Result.Failure<List<PartyRes>>(PartyErrors.NotFound);
        }
    }
}
