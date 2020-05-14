using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using FluentValidation;
using Shared.Constants;

namespace Application.Orders.Commands.AddNewOrder
{
   public class NewOrderItemValidator : AbstractValidator<NewOrderItem>
    {
        public NewOrderItemValidator()
        {
            RuleFor(e => e.Sku)
                .NotEmpty().WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEM_SKU_INVALID);

            RuleFor(e => e.Amount)
                .GreaterThanOrEqualTo(0).WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEM_AMOUNT_INVALID);

            RuleFor(e => e.Price)
                .GreaterThan(0.0).WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEM_PRICE_INVALID);

        }
    }
}
