using Application.Common.Mappings;
using Domain.Entities;


namespace Application.Customers.Queries.GetAllCustomersWithoutOrders
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
