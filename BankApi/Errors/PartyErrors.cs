namespace BankApi.Errors
{
    public class PartyErrors
    {
        public static Error NotFound => new Error("Party.NotFound","Party not found",StatusCodes.Status404NotFound);
        public static Error BadRequest => new Error("Party.BadRequest","Incorrect party data",StatusCodes.Status400BadRequest);
    }
}
