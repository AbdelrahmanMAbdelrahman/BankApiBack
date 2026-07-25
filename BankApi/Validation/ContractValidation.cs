using BankApi.Contracts.Contract;
using FluentValidation;

namespace BankApi.Validation
{
    public class ContractValidation:AbstractValidator<ContractReq>
    {
        public ContractValidation()
        {
            RuleFor(c=>c.contractType).NotEmpty().WithMessage("{propertyName} Can't be empty");
            RuleFor(c=>c.contractNumber).NotEmpty().WithMessage("{propertyName} Can't be empty")
                .MinimumLength(3).WithMessage("{propertyName} must be more than {minLength}");
            RuleFor(c=>c.partyID).NotEmpty().WithMessage("{propertyName} Can't be empty");
            RuleFor(c=>c.leasingType).NotEmpty().WithMessage("{propertyName} Can't be empty");
            RuleFor(c => c.partyName).NotEmpty().WithMessage("{propertyName} Can't be empty")
                .MinimumLength(3).WithMessage("{propertyName} must be more than {minLength}");
            ;
            RuleFor(c=>c.iSLetter).NotEmpty().WithMessage("{propertyName} Can't be empty");
        }
    }
}
