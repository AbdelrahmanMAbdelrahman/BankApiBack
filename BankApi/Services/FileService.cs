
using BankApi.Contracts.File;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using Mapster;


namespace BankApi.Services
{
    public class FileService(DatabaseContext context) : IFileService
    {
        private readonly  string fileDirectory=@"C:\BankImages\";

        public async Task<Result<UploadedFileDownload>> getFile(Guid id, CancellationToken ct)
        {
            UploadedImage? image=await context.Images.FindAsync(id,ct);
            if (image is null) return Result.Failure<UploadedFileDownload>(FileErrors.NotFound);
            string fullPath = Path.Combine(fileDirectory, image.StoredFileName);
            FileStream fileStream =File.OpenRead(fullPath);
            UploadedFileDownload uploadedFileDownload = 
                new UploadedFileDownload(image.FileName,image.ContentType,fileStream);
            return Result.Success(uploadedFileDownload);
        }

        public async Task<UploadedFileReq> UploadFileAsync(IFormFile image, CancellationToken ct)
        {
            string imageExtn=Path.GetExtension(image.FileName);
           string fileName=Guid.NewGuid().ToString()+imageExtn;
            if(!Directory.Exists(fileDirectory))Directory.CreateDirectory(fileDirectory);
            string fullPath = fileDirectory + fileName;
            using FileStream fileStream = File.OpenWrite(fullPath) ;
            await image.CopyToAsync(fileStream);

            return new UploadedFileReq   
                (Guid.Empty,
                image.FileName, 
                image.Length,
                image.ContentType,
                imageExtn,
                fileName
                );
        }
    }
}
