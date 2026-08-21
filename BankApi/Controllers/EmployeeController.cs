using BankApi.Contracts.Employee;
using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Services;
using BankApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployee employee):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetEmployees([FromQuery]PaginatedReq req,CancellationToken ct)
        
        {
            Result<PaginatedList<EmployeeRes>> res = await employee.GetAll(req,ct);
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
        public async Task<IActionResult> EditEmployee([FromForm]EmployeeReq req, Guid id, CancellationToken ct) {
            Result result = await employee.UpdateEmployee(req, id, ct);
            return result.IsSuccess?NoContent():result.ToProblem();

        }
    }
}
