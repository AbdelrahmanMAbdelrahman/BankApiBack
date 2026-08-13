using BankApi.Contracts.File;
using BankApi.Errors;

namespace BankApi.Services
{
    public interface IFileService
    {
        Task<Result<UploadedFileDownload>> getFile(Guid id, CancellationToken ct);
        Task<UploadedFileReq> UploadFileAsync(IFormFile image, CancellationToken ct);
    }
}
