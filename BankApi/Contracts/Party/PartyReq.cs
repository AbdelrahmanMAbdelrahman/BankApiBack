namespace BankApi.Contracts.Party
{
    public record PartyReq(
        string internalCode,
  string partyGroupName,
  string active,
  string nativeName,
  string name,
  string partyCode);
}
