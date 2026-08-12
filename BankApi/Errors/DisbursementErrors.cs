namespace BankApi.Errors
{
    public class DisbursementErrors
    {
        public static Error ContractNotFound =>
            new Error("Disbursement.ContractNotFound", "no contract found for this is", StatusCodes.Status404NotFound);
        public static Error FacilityNotFound =>
            new Error("Disbursement.FacilityNotFound", "no Facility found for this is", StatusCodes.Status404NotFound);
        public static Error BadRequest =>
            new Error("Disbursement.BadRequest", "incorrect disbursement data", StatusCodes.Status400BadRequest);
        public static Error NotFound =>
            new Error("Disbursement.NotFound", "no disbursement found for this is", StatusCodes.Status404NotFound);
        public static Error InternalServerError =>
            new Error("Disbursement.InternalServerError", "Internal Server Error", StatusCodes.Status500InternalServerError);
    }
}
