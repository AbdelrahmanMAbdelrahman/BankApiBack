namespace BankApi.Contracts.File
{
    public record UploadedFileRes(
        Guid id,
        string fileName,
        long fileSize,
        string contentType,
        string extension
        
        );
   
}
