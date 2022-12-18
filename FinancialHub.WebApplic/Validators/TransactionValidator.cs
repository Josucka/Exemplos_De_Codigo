using FinancialHub.Domain.Models;
using FluentValidation;

namespace FinancialHub.WebApplic.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionModel>
    {
        public TransactionValidator()
        {
            //RuleFor(x => x.Description).Length(0, 500).WithMessage(ErrorMessages.ExceedMaxLength);

            //RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ErrorMessages.GreaterThan);

            //RuleFor(x => x.Status).IsInEnum().WithMessage(ErrorMessagens.OutOfEnum);

            //RuleFor(x => x.Type).IsInEnum().WithMessage(ErrorMessagens.OutOfEnum);
        }
    }
}
