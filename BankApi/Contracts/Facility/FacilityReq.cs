using BankApi.Enums;

namespace BankApi.Contracts.Facility
{
        
    public record FacilityReq(
        string accountNumber, 
        Guid partyID, 
        Guid currencyID, 
        EnFacilityType facilityType
        );
     
}
