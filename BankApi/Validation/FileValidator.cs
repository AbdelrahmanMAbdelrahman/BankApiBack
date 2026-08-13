using BankApi.Utils.Consts;
using FluentValidation;

namespace BankApi.Validation
{
    public class FileValidator:AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(f => f)
                .Must(f =>
                {
                    BinaryReader binary = new BinaryReader(f.OpenReadStream());
                    byte[] bytes = binary.ReadBytes(2);
                    string extnHex =BitConverter.ToString(bytes);
                    return GlobalConsts.AllowedExtensions.Contains(extnHex)
                    ;
                })
                .WithMessage("File Not Allowed ")
                .When(f=>f is not null);
        }
    }
}
