namespace BankApi.Contracts.Facility
{
    public record FacilityRes(
        Guid id,
        string accountNumber,
        Guid partyID,
        Guid currencyID,
        int facilityType,
        string currencyName,
        string partyName);
                         
}                              
                                 
                              