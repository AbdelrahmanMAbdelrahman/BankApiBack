using BankApi.Contracts.Disbursement;
using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Services;
using BankApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisbursementController(IDisbursement disburse):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetDisbursements([FromQuery]PaginatedReq req,CancellationToken ct)
        {
            Result<PaginatedList<DisbursementRes>> res = await disburse.getAll(req, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisbursement([FromRoute]Guid id,CancellationToken ct)
        {
            Result<DisbursementRes> res = await disburse.getDisbursement(id, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateDisbursement([FromBody]DisbursementReq req,CancellationToken ct)
        {
            Result<DisbursementRes> res = await disburse.createDisbursement(req, ct);
            return res.IsSuccess ?
                Created(nameof(GetDisbursement),res.Value) :
                res.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisbursement([FromBody]DisbursementReq req,[FromRoute]Guid id,CancellationToken ct)
        {
            Result res = await disburse.updateDisbursement(req,id, ct);
            return res.IsSuccess ?
                NoContent() :
                res.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisbursement([FromRoute]Guid id,CancellationToken ct)
        {
            Result res = await disburse.deleteDisbursement(id, ct);
            return res.IsSuccess ?
                NoContent() :
                res.ToProblem();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery]DisbursementSearch search, 
            [FromQuery]PaginatedReq req,
            CancellationToken ct)
        {
            Result<PaginatedList<DisbursementRes>>result = await disburse.Search(search, req, ct);
            return result.IsSuccess ?
                Ok(result.Value) :
                result.ToProblem();
        }
    }
}
