using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Bogus;
using Bogus.DataSets;
using Domain.UnitTests._Builders;
using Domain.UnitTests._Common;
using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Interfaces;
using Shared.Constants;
using Xunit;

namespace Domain.UnitTests.CustomerTests
{
    public class OrderTests
    {
        private readonly string _description;
        private readonly DateTime _createdDate;
        private readonly int _customerId;

        public OrderTests()
        {
            var faker = new Faker();
            _description = faker.Random.Words(5);
            _createdDate = faker.Date.Recent();
            _customerId = faker.Random.Int(0, 2000);
        }

        [Fact]
        public void order_should_be_created()
        {
            List<OrderItem> items = new List<OrderItem>() { OrderItemBuilder.New().Build() };
            var expectedCustomer = new
            {
                Description = _description,
                CreatedDate = _createdDate,
                CustomerId = _customerId,
                Items = items
            };

            var customer = new Order(expectedCustomer.Description, _customerId, expectedCustomer.Items);
            Assert.Equal(customer.Description, expectedCustomer.Description);
        }


        [Theory]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData(null)]
        public void order_description_should_not_be_empty_or_null(string description)
        {
            Assert.Throws<ArgumentException>(() => OrderBuilder.New().WithDescription(description).Build()).WithMessage(ExceptionMessage.DOMAIN_ORDER_DESCRIPTION_INVALID);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(null)]
        public void order_customer_id_should_not_be_zero_or_null_or_less_than_zero(int customerId)
        {
            Assert.Throws<ArgumentException>(() => OrderBuilder.New().WithCustomerId(customerId).Build()).WithMessage(ExceptionMessage.DOMAIN_ORDER_CUSTOMER_ID_INVALID);
        }

        [Fact]
        public void order_items_should_not_be_zero_or_null()
        {
            Assert.Throws<ArgumentException>(() => OrderBuilder.New().WithItems(null).Build()).WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEMS_INVALID);
        }

    }

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
