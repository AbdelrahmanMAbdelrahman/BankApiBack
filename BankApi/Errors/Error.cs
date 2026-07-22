namespace BankApi.Errors
{
    public record Error(string code, string description, int? statusCode = 0)
    {
        public static Error None => new Error(string.Empty, string.Empty); 
    }
}
