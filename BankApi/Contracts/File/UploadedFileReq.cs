namespace BankApi.Contracts.File
{
    public record UploadedFileReq(
        Guid id,
        string fileName,
        long fileSize,
        string contentType,
        string extension,
        string storedFileName
        );
   
}
