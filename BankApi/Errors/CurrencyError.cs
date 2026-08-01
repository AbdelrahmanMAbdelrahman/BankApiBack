namespace BankApi.Errors
{
    public class CurrencyError
    {
        public static Error BadRequest => new Error("Currency.BadRequest","Incorrect Currency Data",StatusCodes.Status400BadRequest);
        public static Error NotFound => new Error("Currency.NotFound","Currency Not Found",StatusCodes.Status404NotFound);
    }
}
