using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Domain.UnitTests._Builders;
using Domain.UnitTests._Common;
using ExpectedObjects;
using Newtonsoft.Json.Serialization;
using Shared.Constants;
using Xunit;

namespace Domain.UnitTests.CustomerTests
{
    public class OrderItemTest
    {
        private readonly int _amount;
        private readonly double _price;

        public OrderItemTest()
        {
            var faker = new Faker();
            _amount = faker.Random.Int(1, 5000);
            _price = faker.Random.Double(0, 25000);
        }

        [Fact]
        public void item_should_be_created()
        {
            var expectedItem = new
            {
                Amount = _amount,
                Price = _price
            };

            var item = new OrderItem(expectedItem.Amount, expectedItem.Price);
            expectedItem.ToExpectedObject().ShouldMatch(item);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        public void order_item_amount_should_not_be_less_or_equal_to_zero(int amount)
        {
            Assert.Throws<ArgumentException>(() => OrderItemBuilder.New().WithAmount(amount).Build()).WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEM_AMOUNT_INVALID);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        public void order_item_price_should_not_be_less_than_zero(double price)
        {
            Assert.Throws<ArgumentException>(() => OrderItemBuilder.New().WithPrice(price).Build()).WithMessage(ExceptionMessage.DOMAIN_ORDER_ITEM_PRICE_INVALID);
        }
    }

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
