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
        private DateTime _createdDate = new Faker().Date.Recent();


        public static OrderBuilder New()
        {
            return new OrderBuilder();
        }

        public OrderBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public Order Build()
        {
            return new Order(_description);
        }
    }
}
