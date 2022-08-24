using FinancialHub.Domain.Models;
using FluentValidation;

namespace FinancialHub.WebApplic.Validators
{
    public class AccountValidator : AbstractValidator<AccountModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessages.Required).Length(0, 200).WithMessage(ErrorMessages.ExceedMaxLength);

            RuleFor(x => x.Description).Length(0, 500).WithMessage(ErrorMessages.ExceedMaxLength);
        }
    }
}
