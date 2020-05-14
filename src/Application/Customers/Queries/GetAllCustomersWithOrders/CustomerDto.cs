using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Customers.Queries.GetAllCustomersWithOrders
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public CustomerDto()
        {
            Orders = new List<OrderDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}