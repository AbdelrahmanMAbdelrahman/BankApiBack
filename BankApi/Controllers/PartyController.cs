using BankApi.Contracts.Party;
using BankApi.Errors;
using BankApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController(IParty party):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> getParties(CancellationToken ct)
        {
            var result = await party.GetAll(ct);
            return result.IsSuccess ? Ok(result) : BadRequest(result.ToProblem());
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateParty([FromBody]PartyReq req, CancellationToken ct) { 
        var result =await party.AddNewParty(req, ct);
            return result.IsSuccess ? Created(nameof(getParty),result) : BadRequest(result.ToProblem());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getParty([FromRoute]Guid id,CancellationToken ct)
        {
            var result = await party.GetParty(id,ct);
            return result.IsSuccess ? Ok(result) : BadRequest(result.ToProblem());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateParty([FromRoute] PartyReq req, [FromQuery] Guid id, CancellationToken ct) { 
       var result=await party.UpdateParty(req,id,ct);
            return result.IsSuccess ? NoContent() : BadRequest(result.ToProblem());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteParty([FromRoute] Guid id, CancellationToken ct) { 
        var result=await party.DeleteParty(id,ct);
            return result.IsSuccess ? NoContent() : BadRequest(result.ToProblem());
        }
    }
}
