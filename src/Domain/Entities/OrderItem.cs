using System;
using Shared.Constants;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int Amount { get; }
        public double Price { get; }

        public OrderItem(int amount, double price)
        {
            if(amount <= 0)
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEM_AMOUNT_INVALID);

            if(price < 0)
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEM_PRICE_INVALID);

            Amount = amount;
            Price = price;
        }
    }
}