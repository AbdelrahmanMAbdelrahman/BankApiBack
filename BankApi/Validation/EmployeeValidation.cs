using BankApi.Contracts.Employee;
using FluentValidation;

namespace BankApi.Validation
{
    public class EmployeeValidation:AbstractValidator<EmployeeReq>
    {
        public EmployeeValidation()
        {
            RuleFor(e => e.fName).NotEmpty().Length(3, 15);
            RuleFor(e => e.lName).NotEmpty().Length(3, 15);
            RuleFor(e => e.officePhone).NotEmpty().Length(11, 15);
            RuleFor(e => e.mobilePhone).NotEmpty().Length(11, 15);
            RuleFor(e => e.title).NotEmpty().Length(2, 15);
            RuleFor(e => e.address).NotEmpty().Length(3, 50);
            RuleFor(e => e.email).NotEmpty().Length(11, 30);
            RuleFor(e => e.department).NotEmpty().Length(3, 50);
            RuleFor(e => e.reportsTo).NotEmpty().Length(3, 50);
            RuleFor(e => e.status).NotEmpty().Length(1, 50);
            RuleFor(e => e.role).NotEmpty().Length(1, 50);
        }
    }
}
