namespace BankApi.Errors
{
    public class FacilityError
    {
        public static Error BadRequest => new Error("Facility.BadRequest","Incorrect Facility data",StatusCodes.Status400BadRequest);
        public static Error NotFound => new Error("Facility.NotFound", "Facility Not Found", StatusCodes.Status404NotFound);
        public static Error InternalServerError => new Error("Facility.InternalServerError", "internal server error", StatusCodes.Status500InternalServerError);
    }
}
