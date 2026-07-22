using BankApi.Contracts.Employee;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class EmployeeMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EmployeeReq, Employee>()
                .Map(des => des.Role, src => src.role)
                .Map(des => des.Status, src => src.status)
                .Map(des => des.MobilePhone, src => src.mobilePhone)
                .Map(des => des.FName, src => src.fName)
                .Map(des => des.LName, src => src.lName)
                .Map(des => des.OfficePhone, src => src.officePhone)
                .Map(des => des.Title, src => src.title)
                .Map(des => des.Address, src => src.address)
                .Map(des => des.Department, src => src.department)
                .Map(des => des.Email, src => src.email)
                .Map(des => des.UserHash, src => src.userHash)
                .Map(des => des.UserName, src => src.userName)
                .Map(des => des.Notes, src => src.notes)
                .Map(des => des.ReportsTo, src => src.reportsTo);
            config.NewConfig<Employee, EmployeeRes>()
                .Map(des => des.id, src => src.Id)
                .Map(des => des.role, src => src.Role)
                .Map(des => des.status, src => src.Status)
                .Map(des => des.mobilePhone, src => src.MobilePhone)
                .Map(des => des.fName, src => src.FName)
                .Map(des => des.lName, src => src.LName)
                .Map(des => des.officePhone, src => src.OfficePhone)
                .Map(des => des.title, src => src.Title)
                .Map(des => des.address, src => src.Address)
                .Map(des => des.department, src => src.Department)
                .Map(des => des.email, src => src.Email)
                .Map(des => des.userHash, src => src.UserHash)
                .Map(des => des.userName, src => src.UserName)
                .Map(des => des.notes, src => src.Notes)
                .Map(des => des.reportsTo, src => src.ReportsTo);
        }
    }
}
