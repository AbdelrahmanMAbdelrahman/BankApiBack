namespace BankApi.Contracts.Facility
{
    public record FacilitySearch(Guid? partyID,Guid? currencyID,int? facilityType,string? accountNumber);
  
}
