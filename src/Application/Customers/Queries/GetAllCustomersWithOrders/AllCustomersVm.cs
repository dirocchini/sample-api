using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetAllCustomersWithOrders
{
    public class AllCustomersVm
    {
        public AllCustomersVm()
        {
            Customers = new List<CustomerDto>();
        }

        public IEnumerable<CustomerDto> Customers { get; set; }
    }
}
