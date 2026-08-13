using BankApi.Contracts.File;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class FileMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UploadedImage, UploadedFileRes>()
                .Map(des => des.contentType, src => src.ContentType)
                .Map(des => des.fileName, src => src.FileName)
                .Map(des => des.fileSize, src => src.FileSize)
                .Map(des => des.extension, src => src.Extension);
        }
    }
}
