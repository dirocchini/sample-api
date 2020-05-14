namespace Application.Orders.Commands.AddNewOrder
{
    public class NewOrderItem
    {
        public string Sku { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}