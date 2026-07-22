
using BankApi.Contracts.Party;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface IParty
    {
        Task<Result<PartyRes>> AddNewParty(PartyReq req, CancellationToken ct);
        Task<Result> DeleteParty(Guid id, CancellationToken ct);
        Task<Result> UpdateParty(PartyReq req, Guid id, CancellationToken ct);
        Task<Result<PartyRes>> GetParty(Guid id, CancellationToken ct);
        Task<Result<List<PartyRes>>> GetAll(CancellationToken ct);
        Task<bool> Commit();
    }
}
