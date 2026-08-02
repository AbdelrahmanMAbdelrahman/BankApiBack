namespace BankApi.Contracts.Facility
{
    public record FacilityRes(
        Guid id,
        string accountNumber,
        Guid partyID,
        Guid currencyID,
        string facilityType,
        string currencyName,
        string partyName);
                         
}                              
                                 
                              