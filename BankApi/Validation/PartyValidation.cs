using BankApi.Contracts.Party;
using FluentValidation;

namespace BankApi.Validation
{
    public class PartyValidation:AbstractValidator<PartyReq>
    {
        public PartyValidation()
        {
            RuleFor(p => p.internalCode).NotEmpty().WithMessage("internal code can't be null")
                .Length(3, 50).WithMessage("internal code must be within range {MinLength} , {MaxLength}");
            RuleFor(p => p.name).NotEmpty().WithMessage("name can't be null")
                .Length(3, 50).WithMessage("name must be within range {MinLength} , {MaxLength}");
            RuleFor(p => p.partyGroupName).NotEmpty().WithMessage("party group name can't be null")
                .Length(3, 50).WithMessage("party group name must be within range {MinLength} , {MaxLength}");
            RuleFor(p => p.partyCode).NotEmpty().WithMessage("party code can't be null")
                .Length(3, 50).WithMessage("party code must be within range {MinLength} , {MaxLength}");
            RuleFor(p => p.nativeName).NotEmpty().WithMessage("native name can't be null")
                .Length(3, 50).WithMessage("native name must be within range {MinLength} , {MaxLength}");
            
        }
    }
}
