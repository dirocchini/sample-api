using System;
using System.Collections.Generic;
using System.Text;
using Application.Customers.Commands.AddNewCustomer;
using FluentValidation;
using FluentValidation.Results;
using Shared.Constants;

namespace Application.Orders.Commands.AddNewOrder
{
    public class AddNewOrderCommandValidator : AbstractValidator<AddNewOrderCommand>
    {
        public AddNewOrderCommandValidator()
        {
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage(ExceptionMessage.DOMAIN_ORDER_DESCRIPTION_INVALID);

            RuleFor(e => e.Items)
                .NotNull().WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEMS_INVALID);
        }
    }
}
