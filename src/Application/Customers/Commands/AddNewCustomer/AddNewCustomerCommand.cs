using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public class Handler : CommandBaseHandler, IRequestHandler<AddNewCustomerCommand, string>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<string> Handle(AddNewCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await context.Customers.FirstOrDefaultAsync(
                    c => c.Email.ToLower().Trim() == request.Email.ToLower().Trim(), cancellationToken);

                if (customer != null)
                    return $"Customer email ({request.Email}) already registered";

                await context.Customers.AddAsync(new Customer(request.Name, request.Email), cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return string.Empty;
            }
        }
    }
}