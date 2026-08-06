using BankApi.Contracts.Facility;
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
    public class FacilityController(IFacility facility):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetFacilities([FromQuery]PaginatedReq req,CancellationToken ct)
        {
            
            Result<PaginatedList<FacilityRes>> facilities = await facility.GetFacilities(req,ct);
            return facilities.IsSuccess ?
                Ok(facilities.Value) :
                facilities.ToProblem();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacility(Guid id,CancellationToken ct)
        {
            Result<FacilityRes> res = await facility.GetFacility(id,ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] FacilitySearch search,
            [FromQuery] PaginatedReq req,
            CancellationToken ct)
        {
            Result<PaginatedList<FacilityRes>>result = await facility.Search(search, req, ct);
            return result.IsSuccess?
                Ok(result.Value) :
                result.ToProblem();
        }
        [HttpGet("Party/{partyId}")]
        public async Task<IActionResult> GetFacilitiesPerParty(Guid partyId,CancellationToken ct)
        {
            Result<List<FacilityRes>> res = await facility.GetFacilitiesPerParty(partyId, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpGet("Currency/{currencyId}")]
        public async Task<IActionResult> GetFacilitiesPerCurrency(Guid currencyId,CancellationToken ct)
        {
            Result<List<FacilityRes>> res = await facility.GetFacilitiesPerCurrency(currencyId, ct);
            return res.IsSuccess ?
                Ok(res.Value) :
                res.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateFacility(FacilityReq req,CancellationToken ct)
        {
            Result<FacilityRes> res = await facility.CreateFacility(req, ct);
            return res.IsSuccess ?
                Created(nameof(GetFacility),res.Value) :
                res.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(Guid id, CancellationToken ct) { 
        Result res=await facility.DeleteFacility(id,ct);
            return res.IsSuccess?
                NoContent():
                res.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacility(FacilityReq req, Guid id, CancellationToken ct) {
            Result res = await facility.UpdateFacility(req,id,ct);
            return res.IsSuccess?
                NoContent() :
                res.ToProblem();
        }
    }
}
