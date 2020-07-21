using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.AddNewOrder
{
    public class AddNewOrderCommand : IRequest<string>
    {
        public AddNewOrderCommand()
        {
            Items = new List<NewOrderItem>();
        }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public List<NewOrderItem> Items { get; set; }



        public class Handler : CommandBaseHandler, IRequestHandler<AddNewOrderCommand, string>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<string> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == request.CustomerId, cancellationToken);

                    if (customer == null)
                        return $"Customer with id {request.CustomerId} not found";

                    var order = mapper.Map<Order>(request);

                    await context.Orders.AddAsync(order, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);

                    return string.Empty;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}
