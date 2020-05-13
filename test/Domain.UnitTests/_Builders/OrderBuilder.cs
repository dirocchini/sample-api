using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Domain.UnitTests.CustomerTests;

namespace Domain.UnitTests._Builders
{
    public class OrderBuilder
    {
        private string _description = new Faker().Random.Words(5);
        private int _customerId = new Faker().Random.Int(0, 2000);
        private List<OrderItem> _items = new List<OrderItem>() { OrderItemBuilder.New().Build() };

        public static OrderBuilder New()
        {
            return new OrderBuilder();
        }

        public OrderBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public OrderBuilder WithCustomerId(int customerId)
        {
            _customerId = customerId;
            return this;
        }

        public OrderBuilder WithItems(List<OrderItem> items)
        {
            _items = items;
            return this;
        }

        public Order Build()
        {
            return new Order(_description, _customerId, _items);
        }
    }
}
