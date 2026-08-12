using BankApi.Contracts.Bank;

using BankApi.Contracts.Pagination;
using BankApi.Errors;
using BankApi.Services;
using BankApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class BankController(IBank bank):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetBanks([FromQuery] PaginatedReq req, CancellationToken ct)
        {
            Result<PaginatedList<BankRes>> res = await bank.getAll(req, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank([FromRoute] Guid id, CancellationToken ct)
        {
            Result<BankRes> res = await bank.getBank(id, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateBank([FromBody] BankReq req, CancellationToken ct)
        {
            Result<BankRes> res = await bank.createBank(req, ct);
            return res.IsSuccess ?
                Created(nameof(GetBank), res.Value) :
                res.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank([FromBody] BankReq req, [FromRoute] Guid id, CancellationToken ct)
        {
            Result res = await bank.updateBank(req, id, ct);
            return res.IsSuccess ?
                NoContent() :
                res.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank([FromRoute] Guid id, CancellationToken ct)
        {
            Result res = await bank.deleteBank(id, ct);
            return res.IsSuccess ?
                NoContent() :
                res.ToProblem();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] BankSearch search,
            [FromQuery] PaginatedReq req,
            CancellationToken ct)
        {
            Result<PaginatedList<BankRes>> result = await bank.Search(search, req, ct);
            return result.IsSuccess ?
                Ok(result.Value) :
                result.ToProblem();
        }
    }
}
