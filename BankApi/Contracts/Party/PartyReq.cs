namespace BankApi.Contracts.Party
{
    public record PartyReq(
        string internalCode,
  string partyGroupName,
  bool active,
  string nativeName,
  string name,
  string partyCode);
}
