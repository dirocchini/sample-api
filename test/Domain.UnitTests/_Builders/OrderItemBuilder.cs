using Bogus;
using Domain.Entities;

namespace Domain.UnitTests._Builders
{
    public class OrderItemBuilder
    {
        private int _amount = new Faker().Random.Int(1, 5000);
        private double _price = new Faker().Random.Double(0, 25000);
        private string _sku = new Faker().Random.Word();

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

        public OrderItemBuilder WithSku(string sku)
        {
            _sku = sku;
            return this;
        }

        public OrderItem Build()
        {
            return new OrderItem(_amount, _price, _sku);
        }
    }
}
