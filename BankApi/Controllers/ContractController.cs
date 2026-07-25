using BankApi.Contracts.Contract;
using BankApi.Contracts.Party;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController(IContract contract) : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult> GetContracts(CancellationToken ct)
        {
            Result<List<ContractRes>> res = await contract.getContracts(ct);
            return res.IsSuccess ? Ok(res.Value) : res.ToProblem();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetContracts([FromRoute] Guid id, CancellationToken ct)
        {
            Result<ContractRes> res = await contract.getContract(id, ct);
            return res.IsSuccess ? Ok(res.Value) : res.ToProblem();

        }
        [HttpGet("Party/{partyID}")]
        public async Task<ActionResult> GetContractsByParty([FromRoute] Guid partyID, CancellationToken ct)
        {
            Result<List<ContractRes>> res = await contract.getContractsByParty(partyID, ct);
            return res.IsSuccess ? Ok(res.Value) : res.ToProblem();

        }
        [HttpGet("{id}/Party")]
        public async Task<ActionResult> GetPartiesByContract([FromRoute] Guid id, CancellationToken ct)
        {
            Result<List<PartyRes>> res = await contract.GetPartiesByContract(id, ct);
            return res.IsSuccess ? Ok(res.Value) : res.ToProblem();

        }
        [HttpPost("")]
        public async Task<IActionResult> CreateContract([FromBody] ContractReq req, CancellationToken ct)
        {
            Result<ContractRes> res = await contract.createContract(req, ct);
            return res.IsSuccess ? Ok(res.Value) : res.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract([FromBody]ContractReq req,[FromRoute] Guid id, CancellationToken ct)
        {
            Result res =await contract.updateContract(req, id, ct);
            return res.IsSuccess?NoContent() : res.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract([FromRoute]Guid id,CancellationToken ct) {
            Result res = await contract.DeleteContract(id, ct);
            return res.IsSuccess?NoContent(): res.ToProblem();
        }
    }
}
