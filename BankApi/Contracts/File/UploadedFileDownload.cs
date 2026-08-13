namespace BankApi.Contracts.File
{
    public record UploadedFileDownload(string fileName,string contentType,FileStream fileStream);

}
