using FluentValidation;
using Shared.Constants;

namespace Application.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerCommandValidator : AbstractValidator<AddNewCustomerCommand>
    {
        public AddNewCustomerCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage(ExceptionMessage.DOMAIN_CUSTOMER_NAME_INVALID);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(ExceptionMessage.DOMAIN_CUSTOMER_EMAIL_INVALID)
                .EmailAddress().WithMessage(ExceptionMessage.DOMAIN_CUSTOMER_EMAIL_FORMAT_INVALID);
        }
    }
}
