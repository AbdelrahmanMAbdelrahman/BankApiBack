using BankApi.Contracts.Employee;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Services
{
    public class EmployeeService(DatabaseContext database) : IEmployee
    {
        public async Task<Result> AddNewEmployee(EmployeeReq req, CancellationToken ct)
        {
         Employee emp=req.Adapt<Employee>();
          await database.Employees.AddAsync(emp);
            return await Commit()?Result.Success():Result.Failure(EmployeeErrors.BadRequest);
        }

        public async Task<bool> Commit()
        {
            return await database.SaveChangesAsync() > 0;
        }

        public Task<Result> DeleteEmployee(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<EmployeeRes>>> GetAll(CancellationToken ct)
        {
            List<Employee> emps = await database.Employees.ToListAsync();

          List<EmployeeRes>res=emps.Adapt<List<EmployeeRes>>();
            return res.Count() > 0 ? Result.Success(res) :
                Result.Failure<List<EmployeeRes>>(EmployeeErrors.NotFound);
        }

        public async Task<Result<EmployeeRes>> GetEmployee(Guid id, CancellationToken ct)
        {
            var emp=await database.Employees.FindAsync(id) ;
            if(emp is null)return Result.Failure<EmployeeRes>(EmployeeErrors.NotFound);
            EmployeeRes res = emp.Adapt<EmployeeRes>();
            return Result.Success(res);
        }

        public async Task<Result> UpdateEmployee(EmployeeReq req, Guid id, CancellationToken ct)
        {
            Employee? emp = await database.Employees.FindAsync(id);
            if (emp is null) return Result.Failure(EmployeeErrors.NotFound);
            req.Adapt(emp);
            return await Commit()  ? Result.Success() : Result.Failure(EmployeeErrors.BadRequest);
        }
    }
}
