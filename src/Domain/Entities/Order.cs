using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Constants;

namespace Domain.Entities
{
    public class Order
    {
        public Order(string description, int customerId, List<OrderItem> items)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_DESCRIPTION_INVALID);

            if (customerId <= 0)
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_CUSTOMER_ID_INVALID);

            if (items == null || !items.Any())
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_ITEMS_INVALID);



            Description = description;
            CreatedDate = DateTime.Now;
            CustomerId = customerId;

            if (Items == null)
                items = new List<OrderItem>();

            Items = items;
        }

        public string Description { get; }
        public DateTime CreatedDate { get; }


        public int CustomerId { get; }
        public Customer Customer { get; }

        public List<OrderItem> Items { get; private set; }
    }
}