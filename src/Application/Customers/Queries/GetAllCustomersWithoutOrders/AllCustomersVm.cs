using System.Collections.Generic;

namespace Application.Customers.Queries.GetAllCustomersWithoutOrders
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
