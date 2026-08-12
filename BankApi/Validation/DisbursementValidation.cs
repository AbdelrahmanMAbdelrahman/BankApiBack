using BankApi.Contracts.Disbursement;
using FluentValidation;

namespace BankApi.Validation
{
    public class DisbursementValidation:AbstractValidator<DisbursementReq>
    {
        public DisbursementValidation()
        {
            RuleFor(d => d.disbursementDate).NotEmpty().WithMessage("{PropertyName} can't be null")
                .Must((date) => date <= DateTime.UtcNow).WithMessage("{PropertyName} can't exceeds current date");
            RuleFor(d=>d.disbursementMethod).NotEmpty().WithMessage("{PropertyName} can't be null");
            RuleFor(d=>d.contractID).NotEmpty().WithMessage("{PropertyName} can't be null");
            RuleFor(d => d.facilityID).NotEmpty().WithMessage("{PropertyName} can't be null");
            RuleFor(d => d.amount).NotEmpty().WithMessage("{PropertyName} can't be null");
        }
    }
}
