using FinancialHub.Domain.Models;
using FluentValidation;

namespace FinancialHub.WebApplic.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            //RuleFor(c => c.Name).NotEmpty().WithMessage(ErrorMenssages.Required).Length(0, 200).WithMessage(ErrorMessages.ExceedMaxLength);

            //RuleFor(x => x.Description).Length(0, 500).WithMessage(ErrorMessages.ExceedMaxLength);
        }
    }
}
