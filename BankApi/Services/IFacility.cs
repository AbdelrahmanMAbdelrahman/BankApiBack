using BankApi.Contracts.Facility;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface IFacility
    {
        Task<Result<FacilityRes>> CreateFacility(FacilityReq req, CancellationToken ct);
        Task<Result> DeleteFacility(Guid id, CancellationToken ct);
        Task<Result<List<FacilityRes>>> GetFacilities(CancellationToken ct);
        Task<Result<List<FacilityRes>>> GetFacilitiesPerCurrency(Guid currencyId, CancellationToken ct);
        Task<Result<List<FacilityRes>>> GetFacilitiesPerParty(Guid partyId, CancellationToken ct);
        Task<Result<FacilityRes>> GetFacility(Guid id, CancellationToken ct);
        Task<Result> UpdateFacility(FacilityReq req, Guid id, CancellationToken ct);
    }
}
