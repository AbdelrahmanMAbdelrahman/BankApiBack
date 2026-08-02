using BankApi.Contracts.Facility;
using FluentValidation;

namespace BankApi.Validation
{
    public class FacilityValidation:AbstractValidator<FacilityReq>
    {
        public FacilityValidation()
        {
            RuleFor(f => f.accountNumber).NotEmpty().WithMessage("{propertyName} can't be empty")
                .Length(3, 10).WithMessage("{propertyName} must be within range {minLength} : {maxLength}");
            RuleFor(f => f.facilityType).NotEmpty().WithMessage("{propertyName} can't be empty");
            RuleFor(f => f.partyID).NotEmpty().WithMessage("{propertyName} can't be empty");
            RuleFor(f => f.currencyID).NotEmpty().WithMessage("{propertyName} can't be empty");
        }
    }
}
