using BankApi.Contracts.Contract;
using BankApi.Contracts.Party;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface IContract
    {
        Task<Result<ContractRes>> createContract(ContractReq req, CancellationToken ct);
        Task<Result> DeleteContract(Guid id, CancellationToken ct);
        Task<Result<ContractRes>> getContract(Guid id, CancellationToken ct);
        Task<Result<List<ContractRes>>> getContractsByParty(Guid partyID, CancellationToken ct);
        Task<Result<List<ContractRes>>> getContracts(CancellationToken ct);
        Task<Result<List<PartyRes>>> GetPartiesByContract(Guid id, CancellationToken ct);
        Task<Result> updateContract(ContractReq req, Guid id, CancellationToken ct);
    }
}
