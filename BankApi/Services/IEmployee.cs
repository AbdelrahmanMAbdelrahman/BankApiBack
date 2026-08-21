using BankApi.Contracts.Employee;
using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Utils;

namespace BankApi.Services
{
    public interface IEmployee
    {
        Task<Result<EmployeeRes>> AddNewEmployee(EmployeeReq req,CancellationToken ct);
        Task<Result> DeleteEmployee(Guid id, CancellationToken ct);
        Task<Result> UpdateEmployee(EmployeeReq req,Guid id, CancellationToken ct);
        Task<Result<EmployeeRes>> GetEmployee(Guid id, CancellationToken ct);
        Task<Result<PaginatedList<EmployeeRes>>> GetAll( PaginatedReq req, CancellationToken ct);
        Task<bool> Commit();
    }
}
