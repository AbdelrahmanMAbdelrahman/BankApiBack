namespace BankApi.Errors
{
    public class BankErrors
    {
        public static Error CurrencyNotFound => new Error("Bank.CurrencyNotFound","no currency found for this id",StatusCodes.Status404NotFound);
        public static Error BadRequest => new Error("Bank.BadRequest","In correct bank data",StatusCodes.Status400BadRequest);
        public static Error NotFound => new Error("Bank.NotFound","Bank Not Found",StatusCodes.Status404NotFound);
        public static Error InternalServerError => new Error("Bank.InternalServerError","Interanl Server error",StatusCodes.Status500InternalServerError);
    }
}
