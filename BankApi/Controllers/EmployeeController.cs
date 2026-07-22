using BankApi.Contracts.Employee;
using BankApi.Errors;
using BankApi.Models;
using BankApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployee employee):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetEmployees(CancellationToken ct)
        {
            Result<List<EmployeeRes>> res = await employee.GetAll(ct);
            return (res.IsSuccess) ? Ok(res) : res.ToProblem();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetEmployee(Guid id,CancellationToken ct) {
            Result<EmployeeRes> res = await employee.GetEmployee(id, ct);
            return res.IsSuccess ? Ok(res) : res.ToProblem();
        }
        [HttpPost("/add")]
        public async Task<IActionResult> AddEmployee(EmployeeReq req,CancellationToken ct) {
            Employee emp = req.Adapt<Employee>();
            Result result = await employee.AddNewEmployee(req, ct);
            EmployeeRes res=emp.Adapt<EmployeeRes>();
            return result.IsSuccess?Ok(res) : result.ToProblem();
        }
        [HttpPost("/{id}/edit")]
        public async Task<IActionResult> EditEmployee(EmployeeReq req, Guid id, CancellationToken ct) {
            Result result = await employee.UpdateEmployee(req, id, ct);
            return result.IsSuccess?NoContent():result.ToProblem();

        }
    }
}
