using BankApi.Contracts.Currency;
using BankApi.Errors;
using BankApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class CurrencyController(ICurrency currency):ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetCurrencies(CancellationToken ct)
        {
            Result<List<CurrencyRes>> result =await currency.GetAllCurrencies(ct);
            return result.IsSuccess ? Ok(result.Value) : 
                result.ToProblem();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency(Guid id, CancellationToken ct) { 
       Result<CurrencyRes>res=await currency.GetCurrency(id, ct);
            return res.IsSuccess?
                Created(nameof(GetCurrency),res.Value):
                res.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateCurrency(CurrencyReq currencyReq, CancellationToken ct) {
            Result<CurrencyRes> result = await currency.CreateCurrency(currencyReq, ct);
            return result.IsSuccess?
                Ok(result.Value):
                result.ToProblem();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(CurrencyReq currencyReq, Guid id, CancellationToken ct) { 
        Result result=await currency.UpdateCurrency(currencyReq,id, ct);
            return result.IsSuccess?
                   NoContent() :
                   result.ToProblem();
         }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id, CancellationToken ct) { 
        Result result=await currency.DeleteCurrency(id, ct);
            return result.IsSuccess?
                NoContent() :
                result.ToProblem();
        }
    }
}
