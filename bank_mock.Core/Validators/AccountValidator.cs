using bank_mock.Core.Models;
using FluentValidation;

namespace bank_mock.Core.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.IBAN)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(24).WithMessage("{PropertyName} should be 24 characters long");
            
            RuleFor(a => a.AvailableFunds)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .GreaterThan(0).WithMessage("{PropertyName} cannot be negative");
        }
    }
}