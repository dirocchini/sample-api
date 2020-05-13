using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Domain.UnitTests.CustomerTests;

namespace Domain.UnitTests._Builders
{
    public class OrderItemBuilder
    {
        private int _amount = new Faker().Random.Int(1, 5000);
        private double _price = new Faker().Random.Double(0, 25000);

        public static OrderItemBuilder New()
        {
            return new OrderItemBuilder();
        }

        public OrderItemBuilder WithAmount(int amount)
        {
            _amount = amount;
            return this;
        }

        public OrderItemBuilder WithPrice(double price)
        {
            _price = price;
            return this;
        }

        public OrderItem Build()
        {
            return new OrderItem(_amount, _price);
        }
    }
}
