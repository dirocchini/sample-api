using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetAllCustomersWithOrders
{
    public class GetAllCustomerWithOrdersQuery : IRequest<AllCustomersVm>
    {
        public class Handler : QueryBaseHandler, IRequestHandler<GetAllCustomerWithOrdersQuery, AllCustomersVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<AllCustomersVm> Handle(GetAllCustomerWithOrdersQuery request, CancellationToken cancellationToken)
            {
                var customers = await context.Customers
                    .Include(c => c.Orders).ThenInclude(i => i.Items)
                    .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var allCustomersVm = new AllCustomersVm
                {
                    Customers = customers
                };

                return allCustomersVm;
            }
        }
    }
}
