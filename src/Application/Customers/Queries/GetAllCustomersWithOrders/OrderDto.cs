using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Customers.Queries.GetAllCustomersWithOrders
{
    public class OrderDto : IMapFrom<Order>
    {
        public OrderDto()
        {
            Items = new List<OrderItemDto>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
