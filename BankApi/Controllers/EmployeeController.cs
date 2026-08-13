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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id,CancellationToken ct) {
            Result<EmployeeRes> res = await employee.GetEmployee(id, ct);
            return res.IsSuccess ? Ok(res) : res.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromForm]EmployeeReq req,CancellationToken ct) {
            Result<EmployeeRes> result = await employee.AddNewEmployee(req, ct);
            
            return result.IsSuccess ? CreatedAtAction(nameof(GetEmployee),new{id=result.Value.id},result.Value) : result.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(EmployeeReq req, Guid id, CancellationToken ct) {
            Result result = await employee.UpdateEmployee(req, id, ct);
            return result.IsSuccess?NoContent():result.ToProblem();

        }
    }
}
