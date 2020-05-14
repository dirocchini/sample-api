using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Customers.Queries.GetAllCustomersWithOrders
{
    public class OrderItemDto : IMapFrom<OrderItem>
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
