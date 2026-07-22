using BankApi.Contracts.Employee;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface IEmployee
    {
        Task<Result> AddNewEmployee(EmployeeReq req,CancellationToken ct);
        Task<Result> DeleteEmployee(Guid id, CancellationToken ct);
        Task<Result> UpdateEmployee(EmployeeReq req,Guid id, CancellationToken ct);
        Task<Result<EmployeeRes>> GetEmployee(Guid id, CancellationToken ct);
        Task<Result<List<EmployeeRes>>> GetAll( CancellationToken ct);
        Task<bool> Commit();
    }
}
