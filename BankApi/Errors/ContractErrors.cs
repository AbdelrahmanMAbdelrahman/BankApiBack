namespace BankApi.Errors
{
    public class ContractErrors
    {
        public static Error PartyNotFound => new Error("party.NotFound","party not found",StatusCodes.Status404NotFound);
        public static Error BadRequest => new Error("Contract.BadRequest", "in correct Contract data", StatusCodes.Status400BadRequest);
        public static Error Notfound => new Error("Contract.NotFound","Contract not found",StatusCodes.Status404NotFound);
    }
}
