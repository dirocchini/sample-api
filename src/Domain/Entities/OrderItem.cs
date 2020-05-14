using System;
using Domain.Interfaces;
using Shared.Constants;

namespace Domain.Entities
{
    public class OrderItem : IEntity
    {
        protected OrderItem() { }

        public OrderItem(int amount, double price, string sku)
        {
            if (amount <= 0)
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEM_AMOUNT_INVALID);

            if (price < 0)
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEM_PRICE_INVALID);

            if(string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEM_SKU_INVALID);


            Amount = amount;
            Price = price;
            Sku = sku;
        }

        public int Id { get; }

        public string Sku { get; }
        public int Amount { get; }
        public double Price { get; }
    }
}