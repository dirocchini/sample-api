using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Bogus;
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

        public OrderTests()
        {
            var faker = new Faker();
            _description = faker.Random.Words(5);
            _createdDate = faker.Date.Recent();
        }

        [Fact]
        public void order_should_be_created()
        {
            var expectedCustomer = new
            {
                Description = _description,
                CreatedDate = _createdDate
            };

            var customer = new Order(expectedCustomer.Description);
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
        
    }

    public class Order
    {
        public string Description { get; }
        public DateTime CreatedDate { get; }

        public Order(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(ExceptionMessage.DOMAIN_ORDER_DESCRIPTION_INVALID);

            Description = description;
            CreatedDate = DateTime.Now;
        }
    }
}
