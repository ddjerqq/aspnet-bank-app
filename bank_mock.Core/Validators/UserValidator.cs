using bank_mock.Core.Models;
using FluentValidation;

namespace bank_mock.Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(4, 32).WithMessage("{PropertyName} should be from 4 to 32 characters");
        }
    }
}