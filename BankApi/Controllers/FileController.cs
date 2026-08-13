using BankApi.Contracts.File;
using BankApi.Errors;
using BankApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController(IFileService fileService):ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(Guid id ,CancellationToken ct)
        {
            Result<UploadedFileDownload> result = await fileService.getFile(id, ct);
            return result.IsSuccess ?
                File(result.Value.fileStream,result.Value.contentType) :
                result.ToProblem();
        }
    }
}
