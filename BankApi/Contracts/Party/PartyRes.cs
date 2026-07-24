namespace BankApi.Contracts.Party
{
    public record PartyRes(Guid id,
  string internalCode,
  string partyGroupName,
  bool active,
  string nativeName,
  string name,
  string partyCode);
 
}
