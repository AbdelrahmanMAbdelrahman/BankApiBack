namespace BankApi.Contracts.Employee
{
    public record EmployeeRes(
        Guid id ,
        string fName,
        string lName,
        string userName,
        string email,
        string role,
        string status,
        string title,
        string department,
        string userHash,
        string reportsTo,
        string address,
        string officePhone,
        string mobilePhone,
        string notes
       
        );
   
}
