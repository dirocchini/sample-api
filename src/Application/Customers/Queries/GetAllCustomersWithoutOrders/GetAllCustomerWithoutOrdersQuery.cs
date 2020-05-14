using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetAllCustomersWithoutOrders
{

    public class GetAllCustomerWithoutOrdersQuery : IRequest<AllCustomersVm>
    {
        public class Handler : QueryBaseHandler, IRequestHandler<GetAllCustomerWithoutOrdersQuery, AllCustomersVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {

            }

            public async Task<AllCustomersVm> Handle(GetAllCustomerWithoutOrdersQuery request, CancellationToken cancellationToken)
            {
                var customers = await context.Customers.ProjectTo<CustomerDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                var result = new AllCustomersVm { Customers = customers };

                return result;
            }
        }
    }
}