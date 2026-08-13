namespace BankApi.Models
{
    public class Employee
    {
public Guid Id { get; set; }
public Guid? UploadedImageID {  get; set; }
public UploadedImage? UploadedImage { get; set; } = default!;
public string FName { get; set; } = default!;
public string LName { get; set; } = default!;
public string UserName { get; set; } = default!;
public string Email { get; set; } = default!;
public string Role { get; set; } = default!;
public string Status { get; set; } = default!;
public string Title { get; set; } = default!;
public string Department { get; set; } = default!;
public string UserHash { get; set; } = default!;
public string ReportsTo { get; set; } = default!;
public string Address { get; set; } = default!;
public string OfficePhone { get; set; } = default!;
public string MobilePhone { get; set; } = default!;
public string Notes { get; set; } = default!;
    }
}
