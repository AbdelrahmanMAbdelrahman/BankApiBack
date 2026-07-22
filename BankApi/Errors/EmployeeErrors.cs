namespace BankApi.Errors
{
    public static class EmployeeErrors
    {
        public static Error BadRequest => new Error("Employee.BadRequest","Bad Request",StatusCodes.Status400BadRequest);

        public static Error NotFound =>new Error( "Employee.NotFound","Not Found",StatusCodes.Status404NotFound );
    }
}
