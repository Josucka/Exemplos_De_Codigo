using FinancialHub.Domain.Models;
using FluentValidation;

namespace FinancialHub.WebApplic.Validators
{
    public class BalanceValidator : AbstractValidator<BalanceModel>
    {
        public BalanceValidator() : base()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessages.Required).Length(0, 200).WithMessage(ErroMessages.ExceedMaxLength);

            //RuleFor(x => x.AccountId).NotEmpty().WithMessage(ErrorMessages.Required);
        }
    }
}
