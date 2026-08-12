using BankApi.Contracts.Bank;
using BankApi.Models;
using FluentValidation;
using Mapster;

namespace BankApi.Validation
{
    public class BankValidation : AbstractValidator<BankReq>
    {
        public BankValidation()
        {
            RuleFor(b=>b.currencyID).NotEmpty().WithMessage("{PropertyName} can't ");
            RuleFor(b=>b.phone).NotEmpty().WithMessage("{PropertyName} can't ");
            RuleFor(b=>b.eMail).NotEmpty().WithMessage("{PropertyName} can't ");
            RuleFor(b=>b.swiftCode).NotEmpty().WithMessage("{PropertyName} can't ");
            RuleFor(b=>b.fax).NotEmpty().WithMessage("{PropertyName} can't ");
            RuleFor(b=>b.lookupCode).NotEmpty().WithMessage("{PropertyName} can't ");
            
        }
    }
}
